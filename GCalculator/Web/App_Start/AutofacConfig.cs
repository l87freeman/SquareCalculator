using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using Services;
using Services.Interfaces;

namespace Web.App_Start
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder.RegisterType<FileLogReaderService>().As<ILogReader>();
            builder.RegisterType<CalculatorService>().As<ICalculatorService>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);
        }
    }
}