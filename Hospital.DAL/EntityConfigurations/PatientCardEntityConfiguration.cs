using System.Data.Entity.ModelConfiguration;
using Hospital.Core.Models;

namespace Hospital.DAL.EntityConfigurations
{
    public class PatientCardEntityConfiguration : EntityTypeConfiguration<PatientCard>
    {
        public PatientCardEntityConfiguration()
        {
            HasOptional(pt => pt.Patient)
                .WithRequired(p=>p.PatientCard);
            HasMany(pt => pt.Diagnoses)
                .WithRequired(d => d.PatientCard);
        }
    }
}