using System.Collections.Generic;
using System.Data.Entity;
using Hospital.Core.Models;

namespace Hospital.DAL
{

    public class HospitalInitializer : DropCreateDatabaseAlways<HospitalContext>
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
            var uniquePassword = "admin1";




            var doctorRole = new Role {Name = "doctor"};
            var admin = new User {Roles = new List<Role> {new Role {Name = "admin"}}, Email = "admin@hospital.com.ua", UserName = "admin", FirstName = "Nikita", LastName = "Watashi", PasswordHash = uniquePassword };
            var nurse = new User { Roles = new List<Role> { new Role { Name = "nurse" } }, Email = "nurse@hospital.com.ua", UserName = "nurse", FirstName = "Nikita", LastName = "GaDono", PasswordHash = uniquePassword };
            var doctor = new Doctor { Roles = new List<Role> { doctorRole }, Email = "doctor@hospital.com.ua", UserName = "doctor", FirstName = "Nikita", LastName = "YōNiKokoromiru", PasswordHash = uniquePassword };
            var patientRole = new Role {Name = "patient"};

            var patients = new List<Patient>
            {
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "KaMitekudasai" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "A" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "B" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "C" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "D" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "E" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "F" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "G" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "K" },
                new Patient { PasswordHash = uniquePassword, Roles = new List<Role>{patientRole},Email = "patient@gmail.com", UserName = "patient", FirstName = "Nikita", LastName = "L" }
            };

            #endregion

            #region Add users and roles to context
            context.Users.Add(admin);
            context.Users.Add(nurse);
            context.Doctors.Add(doctor);
            context.Patients.AddRange(patients);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}