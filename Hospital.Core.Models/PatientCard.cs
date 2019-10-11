using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class PatientCard : BaseEntity
    {
        public Patient Patient { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }
    }
}