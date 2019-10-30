using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class PrescriptionType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}