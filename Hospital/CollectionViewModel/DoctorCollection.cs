using Hospital.Models.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.CollectionViewModel
{
    public class DoctorCollection
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Nurse> Nurses { get; set; }
    }
}
