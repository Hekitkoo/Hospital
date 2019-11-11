using System.Linq;
using Hospital.Core.Models;

namespace Hospital.Service.Interfaces
{
    public interface ISpecialityService
    {
        void Create(Speciality speciality);
        IQueryable<Speciality> FindById(int? id);
        IQueryable<Speciality> GetAllSpecialities();
    }
}