using Hospital.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Hospital.Services
{
    public class SignInService : SignInManager<User,int>
    {
        public SignInService(UserManager<User, int> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}