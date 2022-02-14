using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PatientPrescription
    {
        [Key]
        public int Id { get; set; }
        public int patientId { get; set; }
        public string doctorId { get; set; }
        public string HospitalId { get; set; }
        public string ChiefComplain { get; set; }
        public string VisitingFees { get; set; }
        public string PatientNotes { get; set; }
        public string createdDate { get; set; }
        public bool isRead { get; set; }
        public string Reference { get; set; }
    }

    public class PrescribedMedicin
    {
        [Key]
        public int Id { get; set; }
        public int patientId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public string Instruction { get; set; }
        public string Day { get; set; }
        public string CreatedDate { get; set; }
        public string HospitalId { get; set; }
        public string Insurance { get; set; }
        public string DoctorId_Or_NurseId {get; set;}
    }

    public class PrescribedDiagnosis
    {
        [Key]
        public int Id { get; set; }
        public int patientId { get; set; }
        public string Diagnosis { get; set; }
        public string Instruction { get; set; }
        public string HospitalId { get; set; }
        public string DoctorId_Or_NurseId { get; set; }
    }

    public class PatientCaseStudy
    {
        [Key]
        public int Id { get; set; }
        public string patientId { get; set; }
        public string HospitalId { get; set; }
        public string DoctorId_Or_NurseId { get; set; }
        public string CreatedDate { get; set; }
        public string FoodAllergies { get; set; }
        public string TendencyBleed { get; set; }
        public string HeartDisease { get; set; }
        public string HighBloodPressure { get; set; }
        public string Diabetic { get; set; }
        public string Surgery { get; set; }
        public string Accident { get; set; }
        public string Others { get; set; }
        public string FamilyMedicalHistory { get; set; }
        public string CurrentMedication { get; set; }
        public string FemalePregnancy { get; set; }
        public string BreastFeeding { get; set; }
        public string HealthInsurance { get; set; }
        public string LowIncome { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        [NotMapped]
        [Display(Name ="Hospital Name")]
        public string Hospital_Name { get; set; }
        [NotMapped]
        public string Doctor_Nurse_Name { get; set; }
        [NotMapped]
        public string Role { get; set; }
        
    }
}
