using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Service.Interfaces;
using Hospital.Core.Models;
using Hospital.DAL;

namespace Hospital.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalContext _context;
        private readonly UserService _userService;
        private readonly ILoggerService<PatientService> _loggerService;
        private Role _role;

        public PatientService(UserService userService, ILoggerService<PatientService> loggerService, HospitalContext context)
        {
            _userService = userService;
            _loggerService = loggerService;
            _context = context;
        }

        public async Task Create(Patient patient)
        {
            try
            {
                _role = _context.Roles.FirstOrDefault(r => r.Name == "patient");
                patient.Doctor = _context.Doctors.FirstOrDefault(d => d.Id == patient.DoctorId);
                patient.Roles.Add(_role);
                await _userService.CreateAsync(patient);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public bool CheckUniqueness(User patient)
        {
            try
            {
                var userByName = _userService.FindByNameAsync(patient.UserName).Result;
                var userByEmail = _userService.FindByEmailAsync(patient.Email).Result;

                return userByName == null && userByEmail == null;
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public void ChangeDoctor(Patient patient)
        {
            try
            {
                patient.Doctor = _context.Doctors.FirstOrDefault(d => d.Id == patient.DoctorId);
                Update(patient);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public void Delete(Patient patient)
        {
            try
            {
                _userService.DeleteAsync(patient);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
            
        }

        public Patient FindByName(string name)
        {
            try
            {
                return _context.Patients.FirstOrDefault(p => p.UserName == name);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public IQueryable<Patient> FindById(int? id)
        {
            try
            {
                return _context.Patients.Where(p => p.Id == id);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public IQueryable<Patient> GetPatients()
        {
            try
            {
                return _context.Patients;
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public void Update(Patient patient)
        {
            try
            {
                _context.Entry(patient).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }

        }

        public IQueryable<PatientCard> FindCardByPatientId(int? id)
        {
            try
            {
                return from patientCard in _context.PatientCards
                       where patientCard.Patient.Id == id
                       select patientCard;
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