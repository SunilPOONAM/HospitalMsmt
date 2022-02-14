using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.SubAdmin
{
    public class Allotment
    {
        public int AllotmentId { get; set; }
        [Required]
        public string Room { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public DateTime AllotmentDate { get; set; }
        [Required]
        public DateTime DischargeDate { get; set; }
        [Required]
        public string DoctorName{ get; set; }
        [Required]
        public string  Status { get; set; }


    }
}
