using System.Data.Entity.ModelConfiguration;
using Hospital.Core.Models;

namespace Hospital.DAL.EntityConfigurations
{
    public class DoctorEntityConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorEntityConfiguration()
        {
            HasRequired(d => d.Specialty)
                .WithMany(dt => dt.Doctors);
            HasMany(d=>d.Patients)
                .WithRequired(p=>p.Doctor);
        }
    }
}