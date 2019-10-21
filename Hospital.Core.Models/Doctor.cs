using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Doctor : User
    {
        public Specialty Specialty { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}