using Autofac;
using WebHydra.Framework.Core;

namespace WebHydra.Framework.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces().AsSelf();

            builder.RegisterType<MessageProvider>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}