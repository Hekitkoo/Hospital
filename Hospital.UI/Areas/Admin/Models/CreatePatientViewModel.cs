using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital.UI.Areas.Admin.Models
{
    public class CreatePatientViewModel : BaseEntityViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Login")]
        [Required]
        [MinLength(6)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
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