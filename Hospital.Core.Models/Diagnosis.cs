using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Diagnosis : BaseEntity
    {
        public bool IsCured { get; set; }
        public string DefinitiveDiagnosis { get; set; }
        public virtual PatientCard PatientCard { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }

        public Diagnosis()
        {
            Prescriptions = new List<Prescription>();
        }
    }
}