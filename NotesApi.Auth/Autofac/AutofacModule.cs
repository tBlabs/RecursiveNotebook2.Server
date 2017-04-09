using Autofac;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace NotesApi.Auth
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces().AsSelf();
            builder.RegisterType<JwtEncoder>().AsImplementedInterfaces();
            builder.RegisterType<HMACSHA256Algorithm>().AsImplementedInterfaces();
            builder.RegisterType<JsonNetSerializer>().AsImplementedInterfaces();
            builder.RegisterType<JwtDecoder>().AsImplementedInterfaces();
            builder.RegisterType<JwtValidator>().AsImplementedInterfaces();
        }
    }
}