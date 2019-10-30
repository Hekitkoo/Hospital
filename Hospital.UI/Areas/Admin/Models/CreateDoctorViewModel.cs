using System.Collections.Generic;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Models
{
    public class CreateDoctorViewModel : UserViewModel
    {
        public int SpecialityId { get; set; }
        public IEnumerable<SelectListItem> Speciality { get; set; }
    }
}