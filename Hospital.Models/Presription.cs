namespace Hospital.Core.Models
{
    public class Prescription : BaseEntity
    {
        public Diagnosis Diagnosis { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public PrescriptionType PrescriptionType { get; set; }
    }
}