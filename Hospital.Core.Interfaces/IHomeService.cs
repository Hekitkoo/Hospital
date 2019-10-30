using System.Threading.Tasks;

namespace Hospital.Core.Interfaces
{
    public interface IHomeService
    {
        Task<bool> LogIn(string username, string password, bool rememberMe);
        void SignOut(string authType);
    }
}