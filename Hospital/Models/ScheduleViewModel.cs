using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ScheduleViewModel
    {
        public string Disease { get; set; }
        public List<ApplicationUser> DoctorList { get; set; }
        public List<string> DoctorTimeSlot { get; set; }
    }
}
