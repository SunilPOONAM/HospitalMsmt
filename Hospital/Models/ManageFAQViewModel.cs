using Hospital.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ManageFAQViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string EncryptedID { get; set; }
        public ManageFAQ ConvertToManageFAQ(ManageFAQViewModel faqModel)
        {
            return new ManageFAQ
            {
                Id = faqModel.Id,
                Question = faqModel.Question,
                Answer = faqModel.Answer,
                CreatedDate = faqModel.CreatedDate
            };
        }
    }
}
