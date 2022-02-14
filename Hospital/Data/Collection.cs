using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Data
{
    public class Collection
    {
        public IEnumerable<PricingPacks> PricingPack { get; set; }
        public IEnumerable<ManageFAQ> ManageFAQ { get; set; }
        public IEnumerable<AppFeatures> AppFeatures { get; set; }

    }
}
