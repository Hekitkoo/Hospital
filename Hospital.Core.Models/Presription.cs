namespace Hospital.Core.Models
{
    public class Prescription : BaseEntity
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public PrescriptionType PrescriptionType { get; set; }
    }
}