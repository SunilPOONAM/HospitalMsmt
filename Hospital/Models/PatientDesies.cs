using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PatientDesies
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId{ get; set; }
        public string ScheduleId { get; set; }
        public string Desies { get; set; }
    }
}
