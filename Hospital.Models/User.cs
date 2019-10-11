using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}