using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class PatientCard : BaseEntity
    {
        public ICollection<Diagnosis> Diagnoses { get; set; }
        public Patient Patient { get; set; }
    }
}