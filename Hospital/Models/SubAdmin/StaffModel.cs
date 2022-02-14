using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.Models.SuperAdminModels;

namespace Hospital.Models.SubAdmin
{
    [NotMapped]
    public class StaffModel
    {
        public string Id { get; set; }
        [Display(Name = "Staff Name")]
        [Required(ErrorMessage = "Field is required.")]
        [MinLength(5, ErrorMessage = "Invalid staff name.")]
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Contact No")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public string Logo { get; set; }
        [Display(Name = "Create Date")]
        public string CreateDate { get; set; }
        [Display(Name = "Modified Date")]
        public string ModifiedDate { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public IEnumerable<StateMaster> States { get; set; }
        public IEnumerable<CityStateModel> Cities { get; set; }
        public bool IsDeleted { get; set; }
        public List<string> RoleName { get; set; }
        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }
        public string HospitalID { get; set; }
        public StaffModel()
        {
            States = new List<StateMaster>();
            Cities = new List<CityStateModel>();
        }

    }
}
