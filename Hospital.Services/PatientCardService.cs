using Hospital.Core.Models;
using Hospital.DAL;
using Hospital.Service.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Hospital.Services
{
    class PatientCardService : IPatientCardService
    {
        private readonly HospitalContext _context;
        private readonly ILoggerService<IPatientCardService> _loggerService;
        public PatientCardService(HospitalContext context, ILoggerService<IPatientCardService> loggerService)
        {
            _context = context;
            _loggerService = loggerService;
        }

        public void ChangeDiagnosis(Diagnosis diagnosis)
        {
            try
            {
                _context.Entry(diagnosis).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public void ChangePrescription(Prescription prescription)
        {
            try
            {
                prescription.PrescriptionType =
                    _context.PrescriptionTypes.SingleOrDefault(pt => pt.Id == prescription.PrescriptionTypeId);
                _context.Entry(prescription).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public void CreateDiagnosis(Diagnosis diagnosis)
        {
            try
            {
                diagnosis.PatientCard = _context.PatientCards.SingleOrDefault(pc => pc.Id == diagnosis.PatientCardId);

                _context.Diagnoses.Add(diagnosis);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public void CreatePrescription(Prescription prescription)
        {
            try
            {
                prescription.Diagnosis = _context.Diagnoses.SingleOrDefault(d => d.Id == prescription.DiagnosisId);
                prescription.PrescriptionType =
                    _context.PrescriptionTypes.SingleOrDefault(pt => pt.Id == prescription.PrescriptionTypeId);
                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<PrescriptionType> GetPrescriptionTypes()
        {
            try
            {
                return _context.PrescriptionTypes;
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public IQueryable<PatientCard> FindCardById(int? id)
        {
            try
            {
                return _context.PatientCards.Where(pc => pc.Id == id);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<Diagnosis> FindDiagnosisById(int? id)
        {
            try
            {
                return _context.Diagnoses.Where(d => d.Id == id);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<Prescription> FindPrescriptionById(int? id)
        {
            try
            {
                return _context.Prescriptions.Where(d => d.Id == id);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }
    }
}
