using System.Collections.Generic;
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
        public void CreateSpeciality(Speciality speciality)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Speciality> GetAllSpecialities()
        {
            return _context.Specialties;
        }
    }
}