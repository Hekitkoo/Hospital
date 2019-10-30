namespace Hospital.UI.Areas.Admin.Models
{
    public class DoctorViewModel : BaseEntityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfPatients { get; set; }
        public DoctoTypeViewModel Speciality { get; set; }
    }
}