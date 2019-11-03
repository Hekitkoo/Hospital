using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Owin;

namespace Hospital.UI
{
    public class AutofacConfig
    {
        public static void RegisterAutofacModules(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new DAL.DataLayer());
            builder.RegisterModule(new Services.ServiceLayer());

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(AutoMapperConfig.Initialize());
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}