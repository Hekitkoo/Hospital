using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Hospital.Core.Models
{
    public class User : BaseEntity, IUser<int>
    {
        public string Email { get; set; }
        public bool EmailAddressConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}