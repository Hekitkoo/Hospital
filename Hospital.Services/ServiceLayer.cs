using Autofac;
using Hospital.Core.Interfaces;

namespace Hospital.Services
{
    public class ServiceLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomeService>().As<IHomeService>();
            builder.RegisterType<AdminService>().As<IAdminService>();
            builder.RegisterGeneric(typeof(LoggerService<>)).As(typeof(ILoggerService<>));
        }
    }
}