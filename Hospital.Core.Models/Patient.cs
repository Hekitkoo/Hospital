namespace Hospital.Core.Models
{
    public class Patient : User
    {
        public virtual Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
        public virtual PatientCard PatientCard { get; set; }
    }
}