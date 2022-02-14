using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class Patients
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Patient ID")]
        public int PatientID { get; set; }
        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email  { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public string Street { get; set; }
       
        public int  CountryId { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string  CountryName { get; set; }
        
        public int StateId { get; set; }
        [Required]
        [Display(Name = "State")]
        public string StateName { get; set; }
        
        public int CityId { get; set; }
        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; } 
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } 
        [Required]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string IsActive { get; set; }
        public string HospitalID { get; set; }
        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public string ModifiedDate { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        [Display(Name = "Emergency Contact Name")]
        public string Emergency_Contact_Name { get; set; }
        [Display(Name = "Emergency Contact Number")]
        public string Emergency_Contact_Number { get; set; }
        public string Occupation { get; set; }
        [Display(Name = "Patient Visit Status")]
        public string Patient_Visit_Status { get; set; }
        [Required]
        [Display(Name = "Patient Type")]
        public string Patient_Type { get; set; }
        [Display(Name = "Payment Type")]
        public string Payment_Type { get; set; }
        public string DoctorId { get; set; }
        public string Disease { get; set; }
    }
}
