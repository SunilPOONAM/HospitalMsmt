using Hospital.Models.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.CollectionViewModel
{
    public class ScheduleCollection
    {
        public Schedule Schedule { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Patients> Patients { get; set; }

    }
}
