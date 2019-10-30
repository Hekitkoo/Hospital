using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class PatientCard : BaseEntity
    {
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Diagnosis> Diagnoses { get; set; }

        public PatientCard()
        {
            Diagnoses = new List<Diagnosis>();
        }
    }
}