using Hospital.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IDoctorService : IUserServiceHelper
    {
        Task Create(Doctor doctor);
        IQueryable<Doctor> FindById(int? id);
        IQueryable<Doctor> GetDoctors();
        
    }
}