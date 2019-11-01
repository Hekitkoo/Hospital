using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Models
{
    public class CreatePatientViewModel : UserViewModel
    {
        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }
        // https://stackoverflow.com/questions/19476530/html-dropdownlistfor-selected-value-not-being-set
        public ICollection<SelectListItem> Doctors { get; set; }

        public CreatePatientViewModel()
        {
            Doctors = new List<SelectListItem>();
        }
    }
}