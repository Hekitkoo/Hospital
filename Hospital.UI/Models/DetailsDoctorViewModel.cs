using System.Collections.Generic;

namespace Hospital.UI.Models
{
    public class DetailsDoctorViewModel:DoctorViewModel
    {
        public SpecialityViewModel Speciality { get; set; }
        public ICollection<PatientViewModel> Patients { get; set; }
    }
}