using Autofac;

namespace DHS.Infrastructure.Crosscutting.IOC
{
    public class ModuleIoc : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Configuration.Load(builder);
        }
    }
}
