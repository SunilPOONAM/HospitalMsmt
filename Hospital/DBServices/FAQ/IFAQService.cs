using Hospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.FAQ
{
    public interface IFAQService
    {
        List<ManageFAQ> GetFAQList();
    }
}
