using System.ComponentModel.DataAnnotations;

namespace Hospital.UI.Models
{
    public class PrescriptionViewModel : BaseEntityViewModel
    {
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        public bool IsDone { get; set; }
        public int? DiagnosisId { get; set; }
    }
}