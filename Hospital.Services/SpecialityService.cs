using System;
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
        private readonly ILoggerService<SpecialityService> _loggerService;

        public SpecialityService(HospitalContext context, ILoggerService<SpecialityService> loggerService)
        {
            _context = context;
            _loggerService = loggerService;
        }

        public void Create(Speciality speciality)
        {
            try
            {
                _context.Specialties.Add(speciality);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<Speciality> FindById(int? id)
        {
            try
            {
                return _context.Specialties.Where(s => s.Id == id).AsQueryable();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
           
        }

        public IQueryable<Speciality> GetAllSpecialities()
        {
            try
            {
                return _context.Specialties.AsQueryable();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }
    }
}