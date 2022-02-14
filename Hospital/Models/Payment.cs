using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Payment
    {
        [Key]
        public int id { get; set; }
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Patient ID")]
        public string Patient_ID { get; set; }
        [Required]
        [Display(Name = "Patient Name")]
        public string Patient_Name { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Required]
        [Display(Name = "Payment Detail")]
        public string PaymentDetail { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public string Amount { get; set; }
        [Display(Name = "Deposit Amount")]
        public string Deposit_Amount { get; set; }
        [Display(Name = "Pending Amount")]
        public string Pending_Amount { get; set; }
        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }
        [Display(Name = "Deposit Date")]
        public string Deposit_Date { get; set; }
        public string HospitalID { get; set; }
        [NotMapped]
        public string Payment_Complete { get; set; }
    }
}
