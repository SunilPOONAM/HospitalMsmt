using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.DBServices.FAQ
{
    public class FAQService : IFAQService
    {
        private HMSContext _context;
        public FAQService(HMSContext context)
        {
            _context = context;
        }
        public List<ManageFAQ> GetFAQList()
        {
            var FAQList = _context.ManageFAQ.ToList();
            return FAQList;
        }
    }
}
