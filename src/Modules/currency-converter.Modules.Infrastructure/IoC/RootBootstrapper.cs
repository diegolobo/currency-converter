using currency_converter.Modules.Infrastructure.IoC.Application;
using currency_converter.Modules.Infrastructure.IoC.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace currency_converter.Modules.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new InfrastructureBootstrapper().ChildServiceRegister(services);
        }
    }
}
