using Hospital.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IDoctorService
    {
        Task Add(Doctor doctor);
        Doctor FindById(int? id);
        IEnumerable<Doctor> GetDoctors();
        bool Unique(Doctor doctor);
    }
}