using System.Collections.Generic;
using Hospital.Core.Models;

namespace Hospital.Service.Interfaces
{
    public interface ISpecialityService
    {
        void CreateSpeciality(Speciality speciality);
        IEnumerable<Speciality> GetAllSpecialities();
    }
}