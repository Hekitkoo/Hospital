using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.InteropServices;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL
{



    public class HospitalInitializer : DropCreateDatabaseIfModelChanges<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {

            #region Create type list of doctors

            var specialities = new[]
            {
                "Pediatrician","Traumatologist","Surgeon","Therapist","Cardiologist"
            };

            var typeDoctorsList = new List<Specialty>();

            foreach (var speciality in specialities)
            {
                typeDoctorsList.Add(new Specialty { Name = speciality });
            }

            typeDoctorsList.ForEach(s => context.Specialties.Add(s));
            context.SaveChanges();

            #endregion

            #region Create users and roles

            var admin = new User { Email = "admin@hospital.com.ua", UserName = "admin", FirstName = "Nikita", LastName = "Watashi" };
            var nurse = new User { Email = "nurse@hospital.com.ua", UserName = "nurse", FirstName = "Nikita", LastName = "GaDono" };
            var doctor = new Doctor { Email = "doctor@hospital.com.ua", UserName = "doctor", FirstName = "Nikita", LastName = "YōNiKokoromiru" };
            var patient = new Patient { Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "KaMitekudasai" };
            var adminRole = new Role { Name = "Admin" };
            var doctorRole = new Role { Name = "Doctor" };
            var patientRole = new Role { Name = "Patient" };
            var nurseRole = new Role { Name = "Nurse" };

            #endregion

            #region CreateUserRoleRelationShip

            var userManager = new UserManager<User, int>(new UserStore(context));
            var roleManager = new RoleManager<Role, int>(new RoleStore(context));

            userManager.CreateAsync(admin);
            roleManager.CreateAsync(adminRole);
            userManager.AddToRoleAsync(admin.Id, adminRole.Name);

            userManager.CreateAsync(nurse);
            roleManager.CreateAsync(nurseRole);
            userManager.AddToRoleAsync(nurse.Id, nurseRole.Name);

            userManager.CreateAsync(doctor);
            roleManager.CreateAsync(doctorRole);
            userManager.AddToRoleAsync(doctor.Id, doctorRole.Name);

            userManager.CreateAsync(patient);
            roleManager.CreateAsync(patientRole);
            userManager.AddToRoleAsync(patient.Id, patientRole.Name);

            #endregion

            base.Seed(context);
        }
    }
}