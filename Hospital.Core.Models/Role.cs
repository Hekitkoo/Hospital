﻿using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Hospital.Core.Models
{
    public class Role : BaseEntity, IRole<int>
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}