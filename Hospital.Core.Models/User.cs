using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Hospital.Core.Models
{
    public class User : BaseEntity, IUser<int>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string SecurityStamp { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<UserClaim> UserClaims { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }


    }
}