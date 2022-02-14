using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class CountryMaster
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Text)]
        public string CountryName { get; set; }
        public bool isActive { get; set; }
    }
}
