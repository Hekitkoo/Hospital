using System.Collections.Generic;
using AutoMapper;
using Hospital.Core.Models;
using Hospital.UI.Areas.Admin.Models;

namespace Hospital.UI
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Patient,IndexPatientViewModel>().ReverseMap();
            CreateMap<Patient, CreatePatientViewModel>().ReverseMap();
            CreateMap<Patient, ChangeDoctorViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();
            CreateMap<Specialty, DoctoTypeViewModel>().ReverseMap();
        }
    }
}