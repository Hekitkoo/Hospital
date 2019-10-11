namespace Hospital.Core.Models
{
    public class Patient : User
    {
        public PatientCard PatientCard { get; set; }
        public Doctor Doctor { get; set; }
    }
}