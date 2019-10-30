using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.DAL;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalContext _context;
        private readonly UserService _userService;
        private readonly ILoggerService<DoctorService> _loggerService;
        private readonly RoleService _roleService;
        private const string RoleName = "doctor";
        public DoctorService(HospitalContext context, UserService userService, ILoggerService<DoctorService> loggerService, RoleService roleService)
        {
            _context = context;
            _userService = userService;
            _loggerService = loggerService;
            _roleService = roleService;
        }

        public async Task Add(Doctor doctor)
        {
            try
            {
                doctor.Specialty = FindSpeciality(doctor.SpecialityId);
                doctor.Roles.Add(await _roleService.FindByNameAsync(RoleName));
                await _userService.CreateAsync(doctor, doctor.PasswordHash);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public Doctor FindById(int? id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors;
        }

        public bool Unique(Doctor doctor)
        {
            var userByName = _userService.FindByNameAsync(doctor.UserName).Result;
            var userByEmail = _userService.FindByEmailAsync(doctor.Email).Result;

            if (userByName != null || userByEmail != null)
            {
                return false;
            }

            return true;
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            return _context.Specialties;
        }

        public Specialty FindSpeciality(int? id)
        {
            return _context.Specialties.FirstOrDefault(s => s.Id == id);
        }
    }
}
