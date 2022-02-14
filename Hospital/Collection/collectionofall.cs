using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Data;
using Hospital.Models.AccountViewModels;
using Hospital.Models.SubAdmin;

namespace Hospital.Collection
{
    public class collectionofall
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Patients> Patients { get; set; }
        public IEnumerable<Appointments> Appointments { get; set; }
        public IEnumerable<Department> Department { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<Allotment> Allotments { get; set; }
        public IEnumerable<PricingPacks> PricingPacks { get; set; }
        public IEnumerable<ManageFAQ> ManageFAQs { get; set; }
        public IEnumerable<AppFeatures> AppFeatures { get; set; }
        public IEnumerable<ApplicationUser> applicationUsers { get; set; }
        public IEnumerable<Nurse> Nurses { get; set; }
    }
}
