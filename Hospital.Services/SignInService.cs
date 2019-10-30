using Hospital.Core.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Hospital.Services
{
    public class SigninService :SignInManager<User,int>
    {
        public SigninService(UserService userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}