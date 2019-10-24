using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.DAL;

namespace Hospital.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalContext _context;

        public PatientService(HospitalContext context)
        {
            _context = context;
        }
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public User FindByName(string name)
        {
            return _context.Patients.FirstOrDefault(p => p.UserName == name);
        }

        public Patient FindById(int? id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients;
        }

        public void Update(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}