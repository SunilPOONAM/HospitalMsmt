using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class RoleMaster
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Role")]
        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Text)]
        public string Role { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
