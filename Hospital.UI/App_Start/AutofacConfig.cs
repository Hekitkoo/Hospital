using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Hospital.UI
{
    public class AutofacConfig
    {
        public static void RegisterAutofacModules()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DAL.DataLayer());
            builder.RegisterModule(new Services.ServiceLayer());

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}