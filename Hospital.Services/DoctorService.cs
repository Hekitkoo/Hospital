using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.DAL;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalContext _context;
        public DoctorService(HospitalContext context)
        {
            _context = context;
        }

        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }

        public Doctor FindByName(string name)
        {
            return _context.Doctors.FirstOrDefault(d => d.UserName == name);
        }

        public Doctor FindById(int? id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors;
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
