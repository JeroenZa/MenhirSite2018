using Autofac;

namespace MenhirSite.BusinessLogic.Helpers.AuthenticationHelpers
{
    public static class AuthenticationHelpersRegistrar
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHelper>().As<IPasswordHelper>().InstancePerDependency();
            builder.RegisterType<TokenHelper>().As<ITokenHelper>().InstancePerDependency();
        }
    }
}
