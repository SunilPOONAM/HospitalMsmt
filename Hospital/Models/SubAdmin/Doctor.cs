using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class Doctor
    {
        [Key]
        public int DoctorId{ get; set; }
        
        public string DoctorName { get; set; }
        
        public string DOB { get; set; }
        
        public string Specialization { get; set; }
   
        public string Experience { get; set; }
     
        public string Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        public string PhoneNo { get; set; }
        
        public string FaxNo { get; set; }
      
        public string Street { get; set; }
      
        public string City { get; set; }
      
        public string State { get; set; }
        
        public string ZipCode { get; set; }
        
        public string Country { get; set; }
       
        public string DoctorDetails { get; set; }
       
        public string Password { get; set; }
    
        public string Availiablity { get; set; }

    }

    public class DoctorViewModel
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage ="Please Enter Doctor Name")]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Required(ErrorMessage ="Please Enter DOB")]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }
        [Required(ErrorMessage ="Please Enter Specialization")]
        public string Specialization { get; set; }
        [Required(ErrorMessage = "Please Enter Experience")]
        public string Experience { get; set; }
        public string Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [Display(Name = "Fax No.")]
        public string FaxNo { get; set; }
        [Required(ErrorMessage = "Please Enter Street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }
        [Required(ErrorMessage ="Please Enter Zip Code")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Display(Name = "Doctor Details")]
        public string DoctorDetails { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please Enter Availiablity")]
        public string Availiablity { get; set; }
        public string HospitalID { get; set; }

    }
}
