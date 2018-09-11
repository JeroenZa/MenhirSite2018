using Autofac;

namespace MenhirSite.BusinessLogic.Authentication
{
    public class AuthenticationRegistrar
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<Authenticator>().As<IAuthenticator>().InstancePerDependency();
        }

    } 
}