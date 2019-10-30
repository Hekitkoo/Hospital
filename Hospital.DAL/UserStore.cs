using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL
{
    public class UserStore : IUserRoleStore<User, int>, IUserPasswordStore<User, int>, IUserEmailStore<User, int>
    {
        private HospitalContext _context;
        // Flag: Has Dispose already been called?
        private bool _disposed;

        public UserStore(HospitalContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Set<User>().Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id.Equals(userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(_context.Set<User>().FirstOrDefault(u => u.UserName == userName));
        }

        public async Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Value cannot be empty.");
            }
            var role = await _context.Set<Role>()
                .SingleOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            if (role == null)
            {
                throw new InvalidOperationException("Role not found: " + roleName);
            }
            user.Roles.Add(role);
            await UpdateAsync(user);
        }

        public async Task RemoveFromRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Value cannot be empty.");
            }
            var role = await _context.Set<Role>()
                .SingleOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            if (role != null)
            {
                var userId = user.Id;
                var userRole = await _context.Set<User>()
                    .FirstOrDefaultAsync(u => u.Roles.Contains(role) && u.Id.Equals(userId));
                if (userRole != null)
                {
                    userRole.Roles.Remove(role);
                    await UpdateAsync(user);
                }
            }
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var contextUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (contextUser == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return contextUser.Roles.Select(r => r.Name).ToList();
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Value cannot be empty.");
            }

            var role = await _context.Set<Role>()
                .SingleOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            if (role != null)
            {
                var contextUser = _context.Set<User>().FirstOrDefault(u => u.Id.Equals(user.Id));
                return contextUser.Roles.Contains(role);
            }

            return false;
        }
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.PasswordHash = passwordHash;
            SaveChanges(user);
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
            
        }

        public Task SetEmailAsync(User user, string email)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            user.Email = email;
            SaveChanges(user);
            return Task.FromResult(0);

        }

        public Task<string> GetEmailAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.EmailAddressConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.EmailAddressConfirmed = confirmed;
            SaveChanges(user);
            return Task.FromResult(0);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Value cannot be empty.");
            }
            return Task.FromResult(_context.Set<User>().FirstOrDefault(u => u.Email == email));
        }

        private void SaveChanges(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}