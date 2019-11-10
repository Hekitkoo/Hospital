using System.Collections.Generic;
using System.Data.Entity;
using Hospital.Core.Models;

namespace Hospital.DAL
{

    public class HospitalInitializer : DropCreateDatabaseAlways<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
            #region property init block
            var password = "admin1";
            var patientRole = new Role { Name = "patient" };
            var doctorRole = new Role { Name = "doctor" };
            #endregion

            #region Create list of doctors
            var specialities = new[]
            {
                "Pediatrician","Traumatologist","Surgeon","Therapist","Cardiologist"
            };
            var lastNames = new[] {"Ariol", "Markay", "Mirkuriy", "Caningem", "Testovich"};
            var doctors = new List<Doctor>();
            for (int i = 0; i < specialities.Length; i++)
            {
                var doctor = new Doctor
                {
                    Roles = new List<Role> {doctorRole}, Speciality = new Speciality {Name = specialities[i]},
                    Email = $"doctor{i}@hospital.com.ua", UserName = $"doctor{i}", FirstName = "Nikita",
                    LastName = lastNames[i], PasswordHash = password
                };
                doctors.Add(doctor);
            }
            #endregion

            #region Create users(patients)
            
            var admin = new User {Roles = new List<Role> {new Role {Name = "admin"}}, Email = "admin@hospital.com.ua", UserName = "admin", FirstName = "Nikita", LastName = "Watashi", PasswordHash = password };
            var nurse = new User { Roles = new List<Role> { new Role { Name = "nurse" } }, Email = "nurse@hospital.com.ua", UserName = "nurse", FirstName = "Nikita", LastName = "GaDono", PasswordHash = password };

            var firstNames = new[] { "Nikita", "Igor", "Misha", "Ira", "Tanya", "Artem", "Pavel", "Irma" };
            var lastNames2 = new[] { "KaMitekudasai" , "Adara", "Badara", "Madara", "Arara", "Irata", "Makynda", "Arkynda", "Lolelo" };
            var patients = new List<Patient>();
            for (int i = 0; i < firstNames.Length; i++)
            {
                var patient = new Patient { PasswordHash = password, Roles = new List<Role> { patientRole }, Email = $"patient{i}@gmail.com", UserName = $"patient{i}", FirstName = firstNames[i], LastName = lastNames2[i] };
                patients.Add(patient);
            }
            #endregion

            #region Add all entity to context
            context.Users.Add(admin);
            context.Users.Add(nurse);
            context.Doctors.AddRange(doctors);
            context.Patients.AddRange(patients);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}