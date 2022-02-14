using Hospital.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class AppFeatureViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FeatureName { get; set; }

        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string EncryptedID { get; set; }
        public AppFeatures ConvertToAppFeatures(AppFeatureViewModel features)
        {
            return new AppFeatures
            {
                Id=features.Id,
                FeatureName = features.FeatureName,
                Description = features.Description,
                IsActive = features.IsActive,
                CreatedDate=features.CreatedDate
            };
        }
    }
}
