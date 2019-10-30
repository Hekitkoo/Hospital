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
            Property(u => u.Birthday).HasColumnType("datetime2");
        }
    }
}