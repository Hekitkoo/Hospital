using System.Web;
using Autofac;
using Hospital.Service.Interfaces;
using Microsoft.AspNet.Identity.Owin;

namespace Hospital.Services
{
    public class ServiceLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorService>().As<IDoctorService>().InstancePerLifetimeScope();
            builder.RegisterType<NurseService>().As<INurseService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<PatientService>().As<IPatientService>().InstancePerLifetimeScope();
            builder.RegisterType<SpecialityService>().As<ISpecialityService>().InstancePerLifetimeScope();
            builder.RegisterType<SigninService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(LoggerService<>)).As(typeof(ILoggerService<>));
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerLifetimeScope();
            builder.Register(c => new IdentityFactoryOptions<UserService>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Hospital​")
            });
           
        }
    }
}