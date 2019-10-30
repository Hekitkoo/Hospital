using System;
using System.Data.Entity.ModelConfiguration;
using Hospital.Core.Models;

namespace Hospital.DAL.EntityConfigurations
{
    public class PatientCardEntityConfiguration : EntityTypeConfiguration<PatientCard>
    {
        public PatientCardEntityConfiguration()
        {
            HasOptional(pt => pt.Patient)
                .WithOptionalDependent(p=>p.PatientCard);
            HasMany(pt => pt.Diagnoses)
                .WithOptional(d => d.PatientCard);
        }
    }
}