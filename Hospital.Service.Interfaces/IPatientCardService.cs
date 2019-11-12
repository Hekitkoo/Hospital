using Hospital.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IPatientCardService
    {
        IQueryable<PatientCard> FindCardById(int? id);
        IQueryable<Diagnosis> FindDiagnosisById(int? id);
        void ChangeDiagnosis(Diagnosis diagnosis);
        void CreateDiagnosis(Diagnosis diagnosis);
        IQueryable<Prescription> FindPrescriptionById(int? id);
        void ChangePrescription(Prescription prescription);
        void CreatePrescription(Prescription prescription);
        IQueryable<PrescriptionType> GetPrescriptionTypes();
    }
}
