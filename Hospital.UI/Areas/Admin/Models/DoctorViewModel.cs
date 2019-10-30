using System.Collections.Generic;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Models
{
    public class DoctorViewModel : BaseEntityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfPatients { get; set; }
    }
}