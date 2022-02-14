using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SuperAdminModels
{
    public class CountryStateModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
    }
}
