namespace Hospital.Core.Models
{
    public class Patient : User
    {
        public Doctor Doctor { get; set; }
        public PatientCard PatientCard { get; set; }
    }
}