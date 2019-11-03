using System.Collections.Generic;
using Hospital.UI.Models;

namespace Hospital.UI.Areas.Admin.Models
{
    public class DetailsSpecialityViewModel : SpecialityViewModel
    {
        public IEnumerable<DoctorViewModel> Doctors { get; set; }
    }
}