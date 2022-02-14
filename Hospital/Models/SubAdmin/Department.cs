using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class Department
    {
       [Key]
        public int DepartmentID { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        public string DepartmentStatus { get; set; }
        public string HospitalID { get; set; }

    }
}
