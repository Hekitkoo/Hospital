using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL
{
    public class RoleStore : IRoleStore<Role,int>
    {
        private readonly HospitalContext _context;

        public RoleStore(HospitalContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Role role)
        {
            _context.Roles.Add(role);
            return Task.FromResult(_context.SaveChangesAsync());
        }

        public Task UpdateAsync(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            return Task.FromResult(_context.SaveChangesAsync());
        }

        public Task DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            return Task.FromResult(_context.SaveChangesAsync());
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            return Task.FromResult(_context.Roles.FirstOrDefault(u => u.Id == roleId));
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.FromResult(_context.Roles.FirstOrDefault(u => u.Name == roleName));
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}