using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Doctor : User
    {
        public virtual Speciality Speciality { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public int SpecialityId { get; set; }
        public Doctor()
        {
            Patients = new List<Patient>();
        }
    }
}