﻿using System.Web;
using Autofac;
using Hospital.Core.Interfaces;
using Microsoft.AspNet.Identity.Owin;

namespace Hospital.Services
{
    public class ServiceLayer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorService>().As<IDoctorService>().InstancePerLifetimeScope();
            builder.RegisterType<HomeService>().As<IHomeService>().InstancePerLifetimeScope();
            builder.RegisterType<PatientService>().As<IPatientService>().InstancePerLifetimeScope();
            builder.RegisterType<SigninService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(LoggerService<>)).As(typeof(ILoggerService<>));
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication);
            builder.Register(c => new IdentityFactoryOptions<Services.UserService>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            });
           
        }
    }
}