using System;
using System.Threading.Tasks;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Hospital.Services
{
    public class UserService : UserManager<User, int>
    {
        public UserService(IUserStore<User, int> userStore, IdentityFactoryOptions<UserService> options)
        : base(userStore)
        {
            UserValidator = new UserValidator<User,int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                //RequireUppercase = true,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                UserTokenProvider =
                    new DataProtectorTokenProvider<User,int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }

        protected override async Task<bool> VerifyPasswordAsync(IUserPasswordStore<User, int> store, User user, string password)
        {
            var psUser = await store.FindByIdAsync(user.Id);
            if (psUser != null)
            {
                return psUser.PasswordHash.Equals(password);
            }
            return false;
        }
    }
}