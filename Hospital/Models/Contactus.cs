using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Contactus
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "(The Email field is required.)")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "(The Name field is required.)")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "(The Message field is required.)")]
        public string Message { get; set; }
        public string Subject { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Date { get; set; }
    }
}
