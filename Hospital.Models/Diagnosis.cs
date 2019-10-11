using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Diagnosis : BaseEntity
    {
        public PatientCard PatientCard { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public bool Cured { get; set; }
        public string DefinitiveDiagnosis { get; set; }
    }
}