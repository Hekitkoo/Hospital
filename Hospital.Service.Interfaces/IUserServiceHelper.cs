using Hospital.Core.Models;

namespace Hospital.Service.Interfaces
{
    public interface IUserServiceHelper
    {
      bool CheckUniqueness(User user);
    }
}
