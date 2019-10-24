using Autofac;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;

namespace Hospital.Services
{
    public class ServiceLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomeService>().As<IHomeService>();
            builder.RegisterType<DoctorService>().As<IDoctorService>();
            builder.RegisterType<RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(LoggerService<>)).As(typeof(ILoggerService<>));
        }
    }
}