using Autofac;
using Hospital.Core.Models;

namespace Hospital.DAL
{
    public class DataLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HospitalContext>().AsSelf().InstancePerRequest();
            //builder.RegisterType<UserStore>().As<User>().InstancePerRequest();
            //builder.RegisterType<RoleStore>().As<Role>().InstancePerRequest();
        }
    }
}