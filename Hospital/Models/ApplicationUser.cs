using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models.SubAdmin;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DOB { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }
        public string Age { get; set; }
        public string FaxNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Country { get; set; }
        [Display(Name = "Doctor Details")]
        public string DoctorDetails { get; set; }
        public string Availiablity { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Role { get; set; }
        public string HospitalID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ContactPersone { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string OTP { get; set; }
        public bool Login { get; set; }
    }
}
