using currency_converter.Adapters.DataAccess.Repositories;
using currency_converter.Adapters.DataRead;
using currency_converter.Modules.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace currency_converter.Modules.Infrastructure.IoC.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<CurrencyReadRepository>();
        }
    }
}
