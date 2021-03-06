﻿using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Models;

namespace Hospital.Service.Interfaces
{
    public interface IPatientService : IUserServiceHelper
    {
        Task Create(Patient patient);
        void ChangeDoctor(Patient patient);
        IQueryable<Patient> FindById(int? id);
        IQueryable<Patient> GetPatients();
    }
}