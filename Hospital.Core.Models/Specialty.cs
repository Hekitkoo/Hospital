using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Specialty : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}