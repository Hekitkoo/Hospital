﻿using System;
using System.Collections.Generic;
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
        private readonly Role _role;
        public DoctorService(HospitalContext context, UserService userService, ILoggerService<DoctorService> loggerService)
        {
            _context = context;
            _userService = userService;
            _loggerService = loggerService;
            _role = _context.Roles.FirstOrDefault(r => r.Name == "doctor");
        }

        public async Task Add(Doctor doctor)
        {
            try
            {
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
    }
}
