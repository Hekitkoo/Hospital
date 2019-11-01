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
    public class PatientService : IPatientService
    {
        private readonly HospitalContext _context;
        private readonly UserService _userService;
        private readonly ILoggerService<PatientService> _loggerService;
        private readonly Role _role;

        public PatientService(UserService userService, ILoggerService<PatientService> loggerService, HospitalContext context)
        {
            _userService = userService;
            _loggerService = loggerService;
            _context = context;
            _role = _context.Roles.FirstOrDefault(r=>r.Name=="patient");
        }

        public async Task Add(Patient patient)
        {
            try
            {
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

        public bool Unique(Patient patient)
        {
            try
            {
                var userByName = _userService.FindByNameAsync(patient.UserName).Result;
                var userByEmail = _userService.FindByEmailAsync(patient.Email).Result;

                if (userByName != null || userByEmail != null)
                {
                    return false;
                }

                return true;
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
            return _context.Patients.FirstOrDefault(p => p.UserName == name);
        }

        public Patient FindById(int? id)
        {
            return _context.Patients.Include(d=>d.Doctor).FirstOrDefault(p => p.Id == id);
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