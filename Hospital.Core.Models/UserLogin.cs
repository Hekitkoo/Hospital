namespace Hospital.Core.Models
{
    public class UserLogin : BaseEntity
    {
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public User User { get; set; }
    }
}