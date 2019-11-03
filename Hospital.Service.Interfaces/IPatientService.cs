using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Models;

namespace Hospital.Service.Interfaces
{
    public interface IPatientService
    {
        Task Add(Patient patient);
        bool CheckUniqueness(Patient patient);
        void ChangeDoctor(Patient patient);
        void Delete(Patient patient);
        Patient FindByName(string name);
        IQueryable<Patient> FindById(int? id);
        IQueryable<Patient> GetPatients();
        void Update(Patient patient);
    }
}