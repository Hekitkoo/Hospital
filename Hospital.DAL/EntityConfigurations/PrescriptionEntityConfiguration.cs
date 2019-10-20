using System.Data.Entity.ModelConfiguration;
using Hospital.Core.Models;

namespace Hospital.DAL.EntityConfigurations
{
    public class PrescriptionEntityConfiguration : EntityTypeConfiguration<Prescription>
    {
        public PrescriptionEntityConfiguration()
        {
            HasRequired(p => p.Diagnosis)
                .WithMany(d => d.Prescriptions);
            HasRequired(p => p.PrescriptionType)
                .WithMany(pt => pt.Prescriptions);
        }
    }
}