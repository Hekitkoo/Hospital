using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Service.Interfaces;
using Hospital.Core.Models;
using Hospital.DAL;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalContext _context;
        private readonly UserService _userService;
        private readonly ILoggerService<DoctorService> _loggerService;
        private Role _role;
        public DoctorService(HospitalContext context, UserService userService, ILoggerService<DoctorService> loggerService)
        {
            _context = context;
            _userService = userService;
            _loggerService = loggerService;
        }

        public async Task Create(Doctor doctor)
        {
            try
            {
                _role = _context.Roles.FirstOrDefault(r => r.Name == "doctor");
                doctor.Speciality = _context.Specialties.FirstOrDefault(s => s.Id == doctor.SpecialityId);
                var role = _role;
                doctor.Roles.Add(role);
                await _userService.CreateAsync(doctor);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<Doctor> FindById(int? id)
        {
            try
            {
                return _context.Doctors.Where(d => d.Id == id).AsQueryable();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<Doctor> GetDoctors()
        {
            try
            {
                return _context.Doctors.AsQueryable();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}"); ;
                throw;
            }
        }

        public bool CheckUniqueness(User doctor)
        {
            try
            {
                var userByName = _userService.FindByNameAsync(doctor.UserName).Result;
            var userByEmail = _userService.FindByEmailAsync(doctor.Email).Result;

            if (userByName != null || userByEmail != null)
            {
                return false;
            }

            return true;
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}"); ;
                throw;
            }
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
