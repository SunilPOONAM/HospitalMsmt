using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Required]
        public string DoctorID { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Display(Name = "Token Number")]
        public string TokenNumber { get; set; }
        [Required]
        public string Problem { get; set; }
        [Required]
        public DateTime? AppointmentDate { get; set; }
        [Required]
        public DateTime? TimeSlot { get; set; }
        [Required]
        public string AppointmentStatus { get; set; }
        public string HospitalID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
