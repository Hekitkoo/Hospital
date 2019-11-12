using System.Collections.Generic;
using System.Web.Mvc;

namespace Hospital.UI.Models
{
    public class CreatePrescriptionViewModel : PrescriptionViewModel
    {
        public int PrescriptionTypeId { get; set; }
        public ICollection<SelectListItem> PrescriptionTypes { get; set; }
    }
}