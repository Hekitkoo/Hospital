using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Core.Models;

namespace Hospital.Core.Interfaces
{
    public interface IPatientService
    {
        Task Add(Patient patient);
        bool Unique(Patient patient);
        void ChangeDoctor(Patient patient);
        void Delete(Patient patient);
        Patient FindByName(string name);
        Patient FindById(int? id);
        IEnumerable<Patient> GetPatients();
        void Update(Patient patient);
    }
}