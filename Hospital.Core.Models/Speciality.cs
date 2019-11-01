using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}