using Autofac;
using Hospital.Core.Models;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL
{
    public class DataLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HospitalContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UserStore>().As<IUserStore<User,int>>().InstancePerLifetimeScope();
            builder.RegisterType<RoleStore>().As<IRoleStore<Role,int>>().InstancePerLifetimeScope();
        }
    }
}