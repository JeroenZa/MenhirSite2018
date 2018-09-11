using Autofac;

namespace MenhirSite.BusinessLogic.Logging
{
    public static class LoggingRegistrar
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<Logger>().As<ILogger>().InstancePerDependency();
        }
    }
}