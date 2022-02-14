using Hospital.Data;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.Features
{
    public class ManageFAQService : IManageFAQService
    {
        private HMSContext _context;
        public ManageFAQService(HMSContext context)
        {
            _context = context;
        }

        public async Task<ManageFAQ> AddFAQ(ManageFAQ manageFAQ)
        {
            _context.ManageFAQ.Add(manageFAQ);
            await _context.SaveChangesAsync();
            return manageFAQ;
        }

        public async Task<ManageFAQ> DeleteFAQByID(int id)
        {
            var data = await _context.ManageFAQ.FindAsync(id);
            if (data != null)
            {
                _context.Remove(data).CurrentValues.SetValues(id);
                await _context.SaveChangesAsync();
                return data;
            }
            return data;
        }
        
        public IQueryable<ManageFAQ> GetAllFAQ()
        {
            return from faq in _context.ManageFAQ select faq;
        }

        public IQueryable<ManageFAQ> GetFAQDetailByID(int Id)
        {
            return from faq in _context.ManageFAQ where faq.Id == Id select faq;
        }

        public async Task<ManageFAQ> GetFAQDetailByID(ManageFAQ model)
        {
          var data = await _context.ManageFAQ.FindAsync(model.Id);
            if (data == null)
            {
                return null;
            }
            _context.Entry(data).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
