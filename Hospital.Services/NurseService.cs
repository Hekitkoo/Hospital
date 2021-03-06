﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Models;
using Hospital.DAL;
using Hospital.Service.Interfaces;

namespace Hospital.Services
{
    class NurseService : INurseService
    {
        private readonly UserService _userService;
        private readonly ILoggerService<NurseService> _loggerService;
        private readonly HospitalContext _context;
        private Role _role;

        public NurseService(UserService userService, ILoggerService<NurseService> loggerService, HospitalContext context)
        {
            _userService = userService;
            _loggerService = loggerService;
            _context = context;
        }
        public bool CheckUniqueness(User nurse)
        {
            try
            {
                var userByName = _userService.FindByNameAsync(nurse.UserName)
                    .GetAwaiter()
                    .GetResult();
                var userByEmail = _userService.FindByEmailAsync(nurse.Email)
                    .GetAwaiter()
                    .GetResult();

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

        public IQueryable<User> GetNurses()
        {
            try
            {
                return from nurse in _context.Users
                       where nurse.Roles.Any(r => r.Name == "nurse")
                       select nurse;
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }

        }

        public async Task Create(User user)
        {
            try
            {
                _role = _context.Roles.SingleOrDefault(r => r.Name == "nurse");
                user.Roles.Add(_role);
                await _userService.CreateAsync(user);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public IQueryable<User> FindById(int? id)
        {
            try
            {
                return _context.Users.Where(n => n.Id == id);
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }

        }

        public IQueryable<Prescription> GetPrescriptions()
        {
            try
            {
                return _context.Prescriptions.Where(p => p.PrescriptionType.Name == "NurseType");
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }

        public void ChangePrescriptionStatus(int? id)
        {
            var prescription = _context.Prescriptions.SingleOrDefault(p => p.PrescriptionType.Id == id);
            try
            {
                if (prescription == null) return;
                prescription.IsDone = !prescription.IsDone;
                _context.Entry(prescription).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _loggerService.Error($"{e}");
                throw;
            }
        }
    }
}
