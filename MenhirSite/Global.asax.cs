using Autofac;
using Autofac.Integration.WebApi;
using MenhirSite.Modules;
using System.Reflection;
using System.Web.Http;
using MenhirSite.BusinessLogic;

namespace MenhirSite
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterModule(new EfModule());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new BusinessLogicModule());
            builder.RegisterModule(new WebApiModule());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            WebApiConfig.Register(config);
            config.EnsureInitialized();
        }
    }
}
