using System.Collections.Generic;
using Hospital.Core.Models;

namespace Hospital.UI.Areas.Admin.Models
{
    public class ChangeDoctorViewModel : BaseEntityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<DoctorViewModel> Doctors { get; set; }

    }
}