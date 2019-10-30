using System.Data.Entity.ModelConfiguration;
using Hospital.Core.Models;

namespace Hospital.DAL.EntityConfigurations
{
    public class DoctorEntityConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorEntityConfiguration()
        {
            HasOptional(d => d.Specialty)
                .WithMany(dt => dt.Doctors);
            HasMany(d=>d.Patients)
                .WithOptional(p=>p.Doctor);
        }
    }
}