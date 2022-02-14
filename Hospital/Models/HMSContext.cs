using Hospital.Models.SubAdmin;
using Microsoft.EntityFrameworkCore;
using System;
using Hospital.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models.AccountViewModels;
using Hospital.Models;
using Hospital.Models.CommonModels;

namespace Hospital.Models
{
    public class HMSContext : IdentityDbContext<ApplicationUser>
    {
        public HMSContext(DbContextOptions<HMSContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
        }

        public DbSet<PricingPacks> PricingPacks { get; set; }
        public DbSet<ManageFAQ> ManageFAQ { get; set; }
        public DbSet<AppFeatures> AppFeatures { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Allotment> Allotments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Hospital.Models.Contactus> Contactus { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<StaffModel> Staff { get; set; }
        public DbSet<ChatModel> ChatModels { get; set; }
        public DbSet<PatientPrescription> PatientPrescriptions { get; set; }
        public DbSet<PrescribedMedicin> PrescribedMedicin { get; set; }
        public DbSet<PrescribedDiagnosis> PrescribedDiagnosis { get; set; }
        public DbSet<DiseaseMaster> DiseaseMasters { get; set; }
        public DbSet<PurchasePlans> PurchasePlans { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }
        public DbSet<PatientDocuments> PatientDocuments { get; set; }
        public DbSet<PatientCaseStudy> PatientCaseStudy { get; set; }
    }
}
