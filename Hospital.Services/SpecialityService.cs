using System.Collections.Generic;
using System.Linq;
using Hospital.Core.Models;
using Hospital.DAL;
using Hospital.Service.Interfaces;

namespace Hospital.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly HospitalContext _context;

        public SpecialityService(HospitalContext context)
        {
            _context = context;
        }

        public void Create(Speciality speciality)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Speciality> FindById(int? id)
        {
            return _context.Specialties.Where(s => s.Id == id).AsQueryable();
        }

        public IQueryable<Speciality> GetAllSpecialities()
        {
            return _context.Specialties.AsQueryable();
        }
    }
}