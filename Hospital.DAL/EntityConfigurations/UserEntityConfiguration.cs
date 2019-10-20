using System.Data.Entity.ModelConfiguration;
using Hospital.Core.Models;

namespace Hospital.DAL.EntityConfigurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            HasMany(u => u.Roles)
                .WithMany(r => r.Users);
            HasMany(u => u.UserClaims)
                .WithRequired(uc => uc.User)
                .HasForeignKey(uc => uc.UserdId);
            HasMany(u => u.UserLogins)
                .WithRequired(ul => ul.User)
                .HasForeignKey(ul => ul.UserId);
        }
    }
}