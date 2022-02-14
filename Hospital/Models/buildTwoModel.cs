using Hospital.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class buildTwoModel
    {
        public LoginViewModel login { get; set; }
        public IEnumerable<PricingPacks> pricingPacks { get; set; }
    }
}
