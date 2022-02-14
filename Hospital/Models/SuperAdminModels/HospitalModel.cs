using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SuperAdminModels
{
    [NotMapped]
    public class HospitalModel
    {
        public string Id { get; set; }
        [Display(Name = "Hospital Name")]
        [Required(ErrorMessage = "Field is required.")]
        [MinLength(5,ErrorMessage = "Invalid hospital name.")]
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Contact Persone")]
        public string ContactPersone { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
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
        [Display(Name= "Country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name ="State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public string Logo { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public List<CountryMaster> Countries { get; }
        public IEnumerable<StateMaster> States { get; set; }
        public IEnumerable<CityStateModel> Cities { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
        public bool EmailConfirmed { get; set; }
        public HospitalModel()
        {
            Countries = new List<CountryMaster>();
            States = new List<StateMaster>();
            Cities = new List<CityStateModel>();
        }

    }
}
