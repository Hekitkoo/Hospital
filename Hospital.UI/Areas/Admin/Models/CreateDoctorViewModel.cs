using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Models
{
    public class CreateDoctorViewModel : UserViewModel
    {
        [Required]
        [Display (Name = "Speciality")]
        public int SpecialityId { get; set; }
        public IEnumerable<SelectListItem> Specialities { get; set; }
    }
}