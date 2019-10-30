using System;

namespace Hospital.UI.Areas.Admin.Models
{
    public class IndexPatientViewModel : BaseEntityViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public DoctorViewModel Doctor { get; set; }
    }
}