using Hospital.Models;
using Hospital.Models.SuperAdminModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class PatientViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Patient ID")]
        public int PatientID { get; set; }
        [Required(ErrorMessage ="Please Enter Patient Name")]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        //[Remote("IsEmailtExists","HospitalAdmin",HttpMethod ="POST",ErrorMessage ="Email already Exists,please  use another email.")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        
        [Display(Name ="Country")]
        public int CountryId { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        [Display(Name ="City"),Required(ErrorMessage ="Please Select City")]
        public int CityId { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Display(Name ="State"),Required(ErrorMessage = "Please Select State")]
        public int StateId { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
        public string Street { get; set; }
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
        [Display(Name = "Emergency Contact Name"),Required(ErrorMessage = "Please Enter Emergency Contact Name")]
        public string Emergency_Contact_Name { get; set; }
        [Display(Name = "Emergency Contact Number")]
        public string Emergency_Contact_Number { get; set; }
        [Required(ErrorMessage = "Please Enter Occupation")]
        public string Occupation { get; set; }
        [Display(Name = "Patient Visit Status")]
        public string Patient_Visit_Status { get; set; }
        //[Required]
        [Display(Name = "Patient Type")]
        public string Patient_Type { get; set; }
        [Display(Name = "Payment Type")]
        public string Payment_Type { get; set; }
        public string DoctorId { get; set; }
        public IEnumerable<StateMaster> StateMasters { get; set; }
        public IEnumerable<CityStateModel> CityMasters { get; set; }
        public IEnumerable<CountryMaster> CountryMasters { get; set; }
        public PatientViewModel()
        {
            StateMasters = new List<StateMaster>();
            CityMasters = new List<CityStateModel>();
            CountryMasters = new List<CountryMaster>();
        }
    }


    public class PrescriptionViewModel
    {
        public int patientId { get; set; }
        public string doctorId { get; set; }
        public string HospitalId { get; set; }
        public string ChiefComplain { get; set; }
        public string VisitingFees { get; set; }
        public string PatientNotes { get; set; }
        public string createdDate { get; set; }
        public string Reference { get; set; }
        public string Insurance { get; set; }
        public string[] MedicineName { get; set; }
        public string[] MedicineType { get; set; }
        public string[] MedicinInstruction { get; set; }
        public string[] Day { get; set; }
        public string[] Diagnosis { get; set; }
        public string[] DignosisInstruction { get; set; }
        public List<PatientPrescription> prescription { get; set; }
        public List<PrescribedMedicin> medicin { get; set; }
        public List<PrescribedDiagnosis> diagnosis { get; set; }
    }


    
}
