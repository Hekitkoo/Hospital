using System.Data.Entity;
using Hospital.Core.Models;
using Hospital.DAL.EntityConfigurations;

namespace Hospital.DAL
{
    public class HospitalContext : DbContext
    {
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCard> PatientCards { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionType> PrescriptionTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public HospitalContext() : base("HospitalContext")
        {
            //Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new HospitalInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DoctorEntityConfiguration());
            modelBuilder.Configurations.Add(new PatientCardEntityConfiguration());
            modelBuilder.Configurations.Add(new PrescriptionEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
