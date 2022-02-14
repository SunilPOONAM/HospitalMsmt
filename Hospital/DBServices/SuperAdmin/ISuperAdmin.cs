using Hospital.Models;
using Hospital.Models.CommonModels;
using Hospital.Models.SuperAdminModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.SuperAdmin
{
    public interface ISuperAdmin
    {
        Task<RequestResponse> CreateHospital(HospitalModel model);

        Task<RequestResponse> UpdateHospital(HospitalModel model);

        Task<RequestResponse> ManageCountry(CountryMaster country);
        Task<RequestResponse> ManageState(StateMaster state);

        Task<HospitalModel> GetHospitalbyId(string Id);

        IEnumerable<HospitalModel> GetHospitalsListAsync();

        Task<RequestResponse> ManageCity(CityMaster city);

        IEnumerable<CountryMaster> CountryList();
        IEnumerable<StateMaster> StateList();
        IEnumerable<CountryStateModel> CountryStateList();
     
        IEnumerable<StateMaster> StateListByCountryId(int CountryId);
       // IEnumerable<CountryMaster> CountryList();

        IEnumerable<CityStateModel> CityList();

      //  IEnumerable<CountryStateModel> StateListByCountryId(int CountryId);
        IEnumerable<CityStateModel> CityListByStateId(int StateId);

        Task<CountryMaster> GetCountry(int Id);
        Task<StateMaster> GetState(int Id);

        Task<CityMaster> GetCity(int Id);

        Task<RequestResponse> CreatePackage(PricingPacks pricingPack);
        Task<RequestResponse> UpdatePackage(PricingPacks pricingPack);


        Task<IEnumerable<PricingPacks>> GetAllPackagesList();


        Task<PricingPacks> GetPricingPackById(int Id);

        Task<RequestResponse> CreateRole(RoleMaster role);
        Task<RoleMaster> GetRole(string Id);
        Task<IEnumerable<RoleMaster>> RoleList();

    }
}
