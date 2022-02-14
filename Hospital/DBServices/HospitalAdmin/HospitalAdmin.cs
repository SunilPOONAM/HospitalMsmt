using Hospital.Models;
using Hospital.Models.CommonModels;
using Hospital.Models.SubAdmin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.HospitalAdmin
{
    public class HospitalAdmin : IHospitalAdmin
    {
        private readonly HMSContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HospitalAdmin(HMSContext _context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context = _context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<RequestResponse> CreateStaff(StaffModel model)
        {
            RequestResponse request = new RequestResponse();
            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Email,
                FirstName = model.StaffName,
                PhoneNumber = model.PhoneNo,
                Email = model.Email,
                City = model.CityId.ToString(),
                State = model.StateId.ToString(),
                ZipCode = model.ZipCode,
                Street = model.Address,
                CreatedDate = DateTime.UtcNow.ToString(),
                IsDeleted = false,
                IsActive = true,
                HospitalID=model.HospitalID,
                UserRole= string.Join(",", model.RoleName)
            };
            var Response = await _userManager.CreateAsync(user, model.Password);
            if (Response.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "StaffMember");
                request.Status = true;
            }
            else
            {
                request.Status = false;
            }
            return request;

        }

        public async Task<RequestResponse> EditStaff(StaffModel model)
        {
            RequestResponse request = new RequestResponse();
            var staff = await _userManager.FindByIdAsync(model.Id);
            if (staff != null)
            {
                staff.FirstName = model.StaffName;
                staff.PhoneNumber = model.PhoneNo;
                staff.City = model.CityId.ToString();
                staff.State = model.StateId.ToString();
                staff.ZipCode = model.ZipCode;
                staff.Street = model.Address;
                staff.ModifiedDate = DateTime.UtcNow.ToString();
                staff.IsActive = true;
                staff.IsDeleted = model.IsDeleted;
                staff.UserRole = string.Join(",", model.RoleName);
            }
            var Response = await _userManager.UpdateAsync(staff);
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
    }
}
