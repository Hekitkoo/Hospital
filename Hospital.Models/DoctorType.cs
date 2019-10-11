using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class DoctorType : BaseEntity
    {
        public string TypeName { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}