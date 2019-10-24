using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Hospital.Core.Models;
using Hospital.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Hospital.Services
{
    public class IdentityService
    {
        private readonly HospitalContext _context;
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        public IdentityService(HospitalContext context, UserService userService, RoleService roleService)
        {

            _context = context;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task Login()
        {


        }

        public async Task InitRolesAndUsers()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                var adminRole = roles.SingleOrDefault(r => r.Name.Equals("admin", StringComparison.CurrentCultureIgnoreCase));
                var admin = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals("admin", StringComparison.CurrentCultureIgnoreCase));
                if (!await _userService.IsInRoleAsync(admin.Id,adminRole.Name))
                {
                    await _userService.AddToRoleAsync(admin.Id, adminRole.Name);
                }
                var nurseRole = roles.SingleOrDefault(r => r.Name.Equals("nurse", StringComparison.CurrentCultureIgnoreCase));
                var nurse = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals("nurse", StringComparison.CurrentCultureIgnoreCase));
                if (!await _userService.IsInRoleAsync(nurse.Id, nurseRole.Name))
                {
                    await _userService.AddToRoleAsync(nurse.Id, nurseRole.Name);
                }
                var doctorRole = roles.SingleOrDefault(r => r.Name.Equals("doctor", StringComparison.CurrentCultureIgnoreCase));
                var doctor = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals("doctor", StringComparison.CurrentCultureIgnoreCase));
                if (!await _userService.IsInRoleAsync(doctor.Id, doctorRole.Name))
                {
                    await _userService.AddToRoleAsync(doctor.Id, doctorRole.Name);
                }
                var patientRole = roles.SingleOrDefault(r => r.Name.Equals("patient", StringComparison.CurrentCultureIgnoreCase));
                var patient = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals("patient", StringComparison.CurrentCultureIgnoreCase));
                if (!await _userService.IsInRoleAsync(patient.Id, patientRole.Name))
                {
                    await _userService.AddToRoleAsync(patient.Id, patientRole.Name);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}