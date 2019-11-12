using System.ComponentModel.DataAnnotations;

namespace Hospital.UI.Models
{
    public class CreateDiagnosisViewModel : BaseEntityViewModel
    {
        [Required]
        public bool IsCured { get; set; }
        [Required]
        [MinLength(10)]
        public string DefinitiveDiagnosis { get; set; }
        public int? PatientCardId { get; set; }
    }
}