using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Doctor : User
    {
        public DoctorType DoctorType { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}