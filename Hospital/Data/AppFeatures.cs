using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Data
{
    public class AppFeatures
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }      
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
    }
}
