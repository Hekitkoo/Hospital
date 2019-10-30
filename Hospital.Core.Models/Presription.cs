namespace Hospital.Core.Models
{
    public class Prescription : BaseEntity
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual PrescriptionType PrescriptionType { get; set; }
    }
}