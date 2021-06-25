using Autofac;
using DHS.Application.Interfaces.Users;
using DHS.Application.Services.Users;
using DHS.Domain.Core.Interfaces;
using DHS.Domain.Core.Interfaces.Repositories;
using DHS.Domain.Core.Services;
using DHS.Domain.Interfaces;
using DHS.Domain.Services;
using DHS.Infrastructure.Data.Repositories;

namespace DHS.Infrastructure.Crosscutting.IOC
{
    public class Configuration
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAppService>()
                   .As<IUserAppService>();

            builder.RegisterGeneric(typeof(DhsCrudAppService<,,,,,,,,,>))
                 .As(typeof(IDhsCrudAppService<,,,,,,,,,>))
                 .InstancePerDependency();

            builder.RegisterGeneric(typeof(Service<,,,,,,,>))
             .As(typeof(IService<,,,,,,>))
             .InstancePerDependency();

            builder.RegisterGeneric(typeof(Repository<,>))
                   .As(typeof(IRepository<,>))
                   .InstancePerDependency();

        }
    }
}
