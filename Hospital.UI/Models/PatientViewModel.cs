using System;

namespace Hospital.UI.Models
{
    public class PatientViewModel : BaseEntityViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? PatientCardId { get; set; }
        public DateTime Birthday { get; set; }
        public DoctorViewModel Doctor { get; set; }
    }
}