using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    [NotMapped]
    public class PatientPrescriptionModel
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        public string doctorId { get; set; }
        public string hospitalId { get; set; }
        [Required]
        [Display(Name = "Prescription")]
        public string prescription { get; set; }
        public string createdDate { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        public bool isRead { get; set; }
    }
}
