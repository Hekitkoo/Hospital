using AutoMapper;
using Hospital.Core.Models;
using Hospital.UI.Areas.Admin.Models;
using Hospital.UI.Models;
using System.Linq;

namespace Hospital.UI
{
    public class AutoMapperConfig : Profile
    {
        private static AutoMapperConfig _profile;
        private AutoMapperConfig()
        {
            CreateMap<Patient, PatientViewModel>();
            CreateMap<Patient, CreatePatientViewModel>().ReverseMap();
            CreateMap<Patient, ChangeDoctorViewModel>();
            CreateMap<Doctor, DoctorViewModel>().ForMember(dv => dv.NumberOfPatients,
                conf => conf.MapFrom(d => d.Patients.Count()));
            CreateMap<Doctor, CreateDoctorViewModel>().ReverseMap();
            CreateMap<Doctor, DetailsDoctorViewModel>();
            CreateMap<Speciality, SpecialityViewModel>().ReverseMap();
            CreateMap<Speciality, DetailsSpecialityViewModel>();
            CreateMap<User, NurseViewModel>();
            CreateMap<CreateNurseViewModel, User>().ReverseMap();
        }

        public static AutoMapperConfig Initialize()
        {
            if (_profile == null)
            {
                _profile = new AutoMapperConfig();
                Mapper.Initialize(cfg => cfg.AddProfile(new AutoMapperConfig()));
            }
            return _profile;
        }
    }
}