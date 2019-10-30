using System.Threading.Tasks;
using Hospital.Core.Interfaces;
using Microsoft.Owin.Security;

namespace Hospital.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserService _userService;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly SigninService _signInManager;

        public AuthenticationService(IAuthenticationManager authenticationManager, UserService userService, SigninService signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }
        public async Task<bool> LogIn(string username, string password, bool rememberMe)
        {
           
            var user = await _userService.FindAsync(username, password);
            if (user == null)
            {
                return false;
            }
            await _signInManager.SignInAsync(user, true, rememberMe);
            return true;
        }

        public void SignOut(string authType)
        {
            _authenticationManager.SignOut(authType);
        }
    }
}