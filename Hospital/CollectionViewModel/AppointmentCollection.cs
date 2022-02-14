using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models.SubAdmin;


namespace Hospital.CollectionViewModel
{
    public class AppointmentCollection
    {
        public Appointments Appointment { get; set; }
        public IEnumerable<Patients> Patients { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Nurse> Nurses { get; set; }
    }
}
