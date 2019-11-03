using Hospital.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IDoctorService
    {
        Task Add(Doctor doctor);
        IQueryable<Doctor> FindById(int? id);
        IQueryable<Doctor> GetDoctors();
        bool CheckUniqueness(Doctor doctor);
    }
}