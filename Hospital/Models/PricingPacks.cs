using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PricingPacks
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Plan Name", Prompt = "Plan name.")]
        public string PlanName { get; set; }
        [Required]
        [Display(Name = "Description", Prompt = "Plan description.")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Billing Period", Prompt = "Billing Period")]
        [DataType(DataType.Text)]
        public string BillingPeroid { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Amount", Prompt = "Amount")]
        public string Amount { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<DateTime> CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }
        [Display(Name = "Plan Type")]
        public PlanType PlanType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Features", Prompt = "Features")]
        public string Features {get; set;}
        public string Features2 { get; set; }
        public string Features3 { get; set; }
        public string Features4 { get; set; }
        public string Features5 { get; set; }
        public string Features6 { get; set; }
        public string Features7 { get; set; }
        public string Features8 { get; set; }
        public string Features9 { get; set; }
        public string Features10 { get; set; }
    }

    public enum PlanType { 
        Free,
        Paid
    }

}
