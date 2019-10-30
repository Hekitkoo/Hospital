using Hospital.Core.Models;
using System.Collections.Generic;

namespace Hospital.Core.Interfaces
{
    public interface IDoctorService
    {
        void Add(Doctor doctor);
        void Delete(Doctor doctor);
        Doctor FindByName(string name);
        Doctor FindById(int? id);
        IEnumerable<Doctor> GetDoctors();
        void Update(Doctor doctor);
    }
}