using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models.SubAdmin;

namespace Hospital.CollectionViewModel
{
    public class PatientCollection
    {
        public Patients Patient { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Nurse> Nurses { get; set; }
    }
}
