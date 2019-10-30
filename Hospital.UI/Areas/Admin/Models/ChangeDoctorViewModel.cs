using System.Collections.Generic;
using System.Web.Mvc;
using Hospital.Core.Models;

namespace Hospital.UI.Areas.Admin.Models
{
    public class ChangeDoctorViewModel : BaseEntityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DoctorId { get; set; }
        public ICollection<SelectListItem> Doctors { get; set; }

    }
}