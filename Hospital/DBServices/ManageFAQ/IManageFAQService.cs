using Hospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.Features
{
    public interface IManageFAQService
    {
        IQueryable<ManageFAQ> GetAllFAQ();
        Task<ManageFAQ> AddFAQ(ManageFAQ appFeatures);
        
        IQueryable<ManageFAQ> GetFAQDetailByID(int Id);
        Task<ManageFAQ> GetFAQDetailByID(ManageFAQ model);
        Task<ManageFAQ> DeleteFAQByID(int id);
    }
}
