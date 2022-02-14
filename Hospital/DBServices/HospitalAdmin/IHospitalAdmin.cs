using Hospital.Models.CommonModels;
using Hospital.Models.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.HospitalAdmin
{
    public interface IHospitalAdmin
    {
        Task<RequestResponse> CreateStaff(StaffModel model);
        Task<RequestResponse> EditStaff(StaffModel model);
    }
}
