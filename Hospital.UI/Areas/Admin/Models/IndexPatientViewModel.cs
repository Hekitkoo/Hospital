using System;

namespace Hospital.UI.Areas.Admin.Models
{
    public class IndexPatientViewModel : BaseEntityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}