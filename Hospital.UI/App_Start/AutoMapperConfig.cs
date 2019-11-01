using AutoMapper;
using Hospital.Core.Models;
using Hospital.UI.Areas.Admin.Models;
using Hospital.UI.Models;

namespace Hospital.UI
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Patient,PatientViewModel>().ReverseMap();
            CreateMap<Patient, CreatePatientViewModel>().ReverseMap();
            CreateMap<Patient, ChangeDoctorViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();
            CreateMap<Doctor, CreateDoctorViewModel>().ReverseMap();
            CreateMap<Speciality, DoctoTypeViewModel>().ReverseMap();
        }
    }
}