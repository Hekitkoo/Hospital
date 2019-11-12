using System.Collections.Generic;

namespace Hospital.UI.Models
{
    public class DiagnosisViewModel : BaseEntityViewModel
    {
        public bool IsCured { get; set; }
        public string DefinitiveDiagnosis { get; set; }
        public ICollection<PrescriptionViewModel> Prescriptions { get; set; }
        public int? PatientCardId { get; set; }
    }
}