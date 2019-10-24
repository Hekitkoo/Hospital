using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.Services
{
    public class RoleService : RoleManager<Role, int>
    {
        public RoleService(IRoleStore<Role, int> roleStore)
        : base(roleStore)
        {

        }
    }
}