using System.Threading.Tasks;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.DAL;
using Microsoft.AspNet.Identity;

namespace Hospital.Services
{
    public class HomeService: IHomeService
    {
        private IdentityService _identityService;
        private readonly HospitalContext _context;
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public HomeService (HospitalContext context, UserService userService, RoleService roleService)
        {
            _context = context;
            _userService = userService;
            _roleService = roleService;
            _identityService = new IdentityService(_context, _userService, _roleService);

        }

        public async Task Test()
        {
            await _identityService.InitRolesAndUsers();
        }
    }
}