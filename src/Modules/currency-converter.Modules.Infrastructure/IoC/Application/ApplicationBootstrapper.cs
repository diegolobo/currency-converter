using currency_converter.Adapters.Provider;
using currency_converter.Modules.Application.Handlers;
using currency_converter.Modules.Domain.Handlers;
using currency_converter.Modules.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace currency_converter.Modules.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddTransient<ICurrencyHandler, CurrencyHandler>();
            services.AddTransient<IRateHandler, RateHandler>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IRateService, RateService>();
        }
    }
}
