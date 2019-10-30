using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL
{
    public class RoleStore : IRoleStore<Role, int>
    {
        private HospitalContext _context;
        // Flag: Has Dispose already been called?
        private bool _disposed;

        public RoleStore(HospitalContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            _context.Set<Role>().Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            _context.Set<Role>().Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> FindByIdAsync(int roleId)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(r => r.Id.Equals(roleId));
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}