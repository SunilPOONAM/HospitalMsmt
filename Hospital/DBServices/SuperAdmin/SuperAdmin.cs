using Hospital.Models;
using Hospital.Models.CommonModels;
using Hospital.Models.SuperAdminModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.SuperAdmin
{
    public class SuperAdmin : ISuperAdmin
    {
        private readonly HMSContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SuperAdmin(HMSContext _context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context = _context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<RequestResponse> ManageCountry(CountryMaster country)
        {
            RequestResponse response = new RequestResponse();
            try
            {
                if (country.Id == 0)
                {
                    country.isActive = true;
                    await context.CountryMasters.AddAsync(country);
                }
                else
                {
                    context.CountryMasters.Update(country);
                }
                await context.SaveChangesAsync();
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<RequestResponse> ManageState(StateMaster state)
        {
            RequestResponse response = new RequestResponse();
            try
            {
                if (state.Id == 0)
                {
                    state.IsActive = true;
                    await context.StateMasters.AddAsync(state);
                }
                else
                {
                    context.StateMasters.Update(state);
                }
                await context.SaveChangesAsync();
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }




        public async Task<RequestResponse> ManageCity(CityMaster city)
        {
            RequestResponse response = new RequestResponse();
            try
            {
                if (city.Id == 0)
                    await context.CityMasters.AddAsync(city);
                else
                    context.CityMasters.Update(city);
                await context.SaveChangesAsync();
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }





        public async Task<RequestResponse> CreateHospital(HospitalModel model)
        {
            RequestResponse request = new RequestResponse();
            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Email,
                FirstName = model.HospitalName,
                PhoneNumber = model.ContactNo,
                Email = model.Email,
                City = model.CityId.ToString(),
                State = model.StateId.ToString(),
                ContactPersone = model.ContactPersone,
                ZipCode = model.ZipCode,
                Street = model.Address,
                CreatedDate = DateTime.UtcNow.ToString(),
                IsDeleted = false,
                IsActive = true
            };
            var Response = await _userManager.CreateAsync(user, model.Password);
            if (Response.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "HospitalAdmin");
                request.Status = true;
            }
            else
            {
                request.Status = false;
            }
            return request;

        }

        public IEnumerable<CountryMaster> CountryList()
        {
            var list = context.CountryMasters.ToList();
            return list;
        }
        public IEnumerable<CountryStateModel> StateList()
        {
            List<CountryStateModel> list = (from c in context.StateMasters
                                            join s in context.CountryMasters on c.CountryId equals s.Id
                                            where c.IsActive == true
                                            select new CountryStateModel
                                            {
                                                Id = c.Id,
                                                CountryName = s.CountryName,
                                                StateName = c.StateName,
                                                IsActive = c.IsActive,
                                                CountryId = c.CountryId,
                                            }).ToList();
            return list;
        }

        public async Task<CountryMaster> GetCountry(int Id)
        {
            return await context.CountryMasters.FindAsync(Id);
        }
        public async Task<StateMaster> GetState(int Id)
        {
            return await context.StateMasters.FindAsync(Id);
        }


        public IEnumerable<CityStateModel> CityList()
        {
            List<CityStateModel> list = (from c in context.CityMasters
                                         join s in context.StateMasters on c.StateId equals s.Id
                                         where c.IsActive == true
                                         select new CityStateModel
                                         {
                                             Id = c.Id,
                                             StateName = s.StateName,
                                             CityName = c.CityName,
                                             IsActive = c.IsActive,
                                             StateId = c.StateId,
                                         }).ToList();
            return list;
        }

        public async Task<CityMaster> GetCity(int Id)
        {
            return await context.CityMasters.FindAsync(Id);
        }



        public async Task<RequestResponse> CreatePackage(PricingPacks pricingPack)
        {
            RequestResponse response = new RequestResponse();
            pricingPack.CreatedDate = DateTime.UtcNow;
            pricingPack.IsDeleted = false;
            await context.PricingPacks.AddAsync(pricingPack);
            await context.SaveChangesAsync();
            response.Status = true;
            return response;
        }
        public async Task<RequestResponse> UpdatePackage(PricingPacks pricingPack)
        {
            RequestResponse response = new RequestResponse();
            pricingPack.ModifiedDate = DateTime.UtcNow;
            context.PricingPacks.Update(pricingPack);
            await context.SaveChangesAsync();
            response.Status = true;
            return response;
        }

        public async Task<IEnumerable<PricingPacks>> GetAllPackagesList()
        {
            return await context.PricingPacks.Where(x => x.IsDeleted == false).ToListAsync();
        }



        public async Task<PricingPacks> GetPricingPackById(int Id)
        {
            return await context.PricingPacks.FindAsync(Id);
        }

        public IEnumerable<CityStateModel> CityListByStateId(int StateId)
        {
            return context.CityMasters.Where(x => x.StateId == StateId).Select(x => new CityStateModel
            {
                Id = x.Id,
                StateId = x.StateId,
                CityName = x.CityName
            }).ToList();
        }

        public IEnumerable<HospitalModel> GetHospitalsListAsync()
        {
            var UserRoleList = context.UserRoles.ToList();
            var RoleList = context.Roles.Where(x => x.Name.Contains("HospitalAdmin")).ToList();
            IEnumerable<HospitalModel> list = (from r in RoleList
                                               join ur in UserRoleList on r.Id equals ur.RoleId
                                               join h in _userManager.Users on ur.UserId equals h.Id
                                               join st in context.StateMasters on Convert.ToInt32(h.State) equals st.Id
                                               join c in context.CityMasters on Convert.ToInt32(h.City) equals c.Id
                                               where (h.IsDeleted == false)
                                               select new HospitalModel()
                                               {
                                                   Id = h.Id,
                                                   HospitalName = h.FirstName,
                                                   ContactNo = h.PhoneNumber,
                                                   ContactPersone = h.ContactPersone,
                                                   Email = h.Email,
                                                   StateName = st.StateName,
                                                   CityName = c.CityName,
                                                   Address = h.Street,
                                                   CreateDate = h.CreatedDate,
                                                   ModifiedDate = h.ModifiedDate,
                                                   RoleName = r.Name,
                                                   IsDeleted = h.IsDeleted,
                                                   IsActive = h.IsActive,
                                                   CityId = h.City != null ? Convert.ToInt32(h.City) : 0,
                                                   StateId = h.State != null ? Convert.ToInt32(h.State) : 0,
                                                   EmailConfirmed = h.EmailConfirmed
                                               }).ToList();
            return list;
        }

        public async Task<HospitalModel> GetHospitalbyId(string Id)
        {
            return await context.Users.Where(x => x.Id.Equals(Id)).Select(x => new HospitalModel()
            {
                Id = x.Id,
                HospitalName = x.FirstName,
                ContactNo = x.PhoneNumber,
                ContactPersone = x.ContactPersone,
                Email = x.Email,
                StateName = x.State,
                CityName = x.City,
                Address = x.Street,
                CreateDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                ZipCode = x.ZipCode,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive
            }).FirstOrDefaultAsync();
        }

        public async Task<RequestResponse> UpdateHospital(HospitalModel model)
        {
            RequestResponse request = new RequestResponse();
            var hospital = await _userManager.FindByIdAsync(model.Id);
            if (hospital != null)
            {
                hospital.FirstName = model.HospitalName;
                hospital.PhoneNumber = model.ContactNo;
                hospital.City = model.CityId.ToString();
                hospital.State = model.StateId.ToString();
                hospital.ContactPersone = model.ContactPersone;
                hospital.ZipCode = model.ZipCode;
                hospital.Street = model.Address;
                hospital.ModifiedDate = DateTime.UtcNow.ToString();
                hospital.IsActive = model.IsActive;
                hospital.IsDeleted = model.IsDeleted;
            }
            var Response = await _userManager.UpdateAsync(hospital);
            if (Response.Succeeded)
            {
                request.Status = true;
            }
            else
            {
                request.Status = false;
            }
            return request;
        }



        public IEnumerable<CountryStateModel> StateListByCountryId(int CountryId)
        {
            return context.StateMasters.Where(x => x.CountryId == CountryId).Select(x => new CountryStateModel
            {
                Id = x.Id,
                CountryId = x.CountryId,
                StateName = x.StateName
            }).ToList();
        }
        public async Task<CountryMaster> GetCountryById(string Id)
        {
            return await context.CountryMasters.Where(x => x.Id.Equals(Id)).Select(x => new CountryMaster()
            {
                Id = x.Id,
                CountryName = x.CountryName,
                isActive = x.isActive
            }).FirstOrDefaultAsync();
        }

        public Task<RequestResponse> CreateRole(RoleMaster role)
        {
            throw new NotImplementedException();
        }

        public Task<RoleMaster> GetRole(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleMaster>> RoleList()
        {
            throw new NotImplementedException();
        }

        IEnumerable<StateMaster> ISuperAdmin.StateListByCountryId(int CountryId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CountryStateModel> ISuperAdmin.CountryStateList()
        {
            List<CountryStateModel> list = (from c in context.StateMasters
                                            join s in context.CountryMasters on c.CountryId equals s.Id
                                            where c.IsActive == true
                                            select new CountryStateModel
                                            {
                                                Id = c.Id,
                                                CountryName = s.CountryName,
                                                StateName = c.StateName,
                                                IsActive = c.IsActive,
                                                CountryId = c.CountryId,
                                            }).ToList();
            return list;
        }

        IEnumerable<StateMaster> ISuperAdmin.StateList()
        {
            var list = context.StateMasters.ToList();
            return list;
        }
    }
}
