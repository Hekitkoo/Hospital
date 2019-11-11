using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Models;

namespace Hospital.Service.Interfaces
{
    public interface IPatientService : IUserServiceHelper
    {
        Task Create(Patient patient);
        void ChangeDoctor(Patient patient);
        void Delete(Patient patient);
        Patient FindByName(string name);
        IQueryable<Patient> FindById(int? id);
        IQueryable<Patient> GetPatients();
        void Update(Patient patient);
        IQueryable<PatientCard> FindCardByPatientId(int? id);
        IQueryable<Diagnosis> FindDiagnosisById(int? id);
        IQueryable<Prescription> FindPrescriptionById(int? id);
    }
}