using Hospital.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface INurseService : IUserServiceHelper
    {
        IQueryable<User> GetNurses();
        Task Create(User user);
        IQueryable<User> FindById(int? id);
        IQueryable<Prescription> GetPrescriptions(int id);
    }
}
