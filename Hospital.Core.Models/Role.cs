using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}