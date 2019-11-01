using System.ComponentModel.DataAnnotations;

namespace Hospital.UI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}