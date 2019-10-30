using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.UI.Areas.Admin.Models
{
    public class UserViewModel : BaseEntityViewModel
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
    }
}