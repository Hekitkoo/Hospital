using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class PrescriptionType : BaseEntity
    {
        public string TypeName { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}