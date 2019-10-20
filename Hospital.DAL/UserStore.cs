using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Core;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL
{
    public class UserStore : IUserStore<User,int>
    {
        private readonly HospitalContext _context;
        public UserStore(HospitalContext context)
        {
            _context = context;
        }

        public Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            return Task.FromResult(_context.SaveChangesAsync());
        }

        public Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return Task.FromResult(_context.SaveChangesAsync());
        }

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.FromResult(_context.SaveChangesAsync());
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return Task.FromResult(_context.Users.FirstOrDefault(u => u.Id == userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(_context.Users.FirstOrDefault(u => u.UserName == userName));
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}