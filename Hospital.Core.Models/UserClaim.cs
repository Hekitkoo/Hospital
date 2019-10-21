namespace Hospital.Core.Models
{
    public class UserClaim : BaseEntity
    {
        public int UserdId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public User User { get; set; }
    }
}