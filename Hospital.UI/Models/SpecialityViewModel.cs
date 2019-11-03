using System.ComponentModel.DataAnnotations;

namespace Hospital.UI.Models
{
    public class SpecialityViewModel : BaseEntityViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}