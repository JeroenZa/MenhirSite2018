using Autofac;
using MenhirSite.BusinessLogic.Logging;
using MenhirSite.BusinessLogic.Authentication;

namespace MenhirSite.BusinessLogic
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoggingRegistrar.Register(builder);
            AuthenticationRegistrar.Register(builder);
        }
    }
}