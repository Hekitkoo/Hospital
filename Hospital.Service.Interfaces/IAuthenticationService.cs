using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LogIn(string username, string password, bool rememberMe);
        void SignOut(string authType);
    }
}
