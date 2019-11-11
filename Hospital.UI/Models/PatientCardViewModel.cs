using System.Collections.Generic;

namespace Hospital.UI.Models
{
    public class PatientCardViewModel : BaseEntityViewModel
    {
        public PatientViewModel Patient { get; set; }
        public ICollection<DiagnosisViewModel> Diagnoses { get; set; }
    }
}