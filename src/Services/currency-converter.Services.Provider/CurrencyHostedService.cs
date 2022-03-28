using currency_converter.Modules.Domain.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace currency_converter.Services.Provider
{
    public class CurrencyHostedService : BackgroundService, IDisposable
    {
        #region Constructors

        public CurrencyHostedService(ILogger<CurrencyHostedService> logger,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            _logger = logger;
            ServiceProvider = serviceProvider;
            _configuration = configuration;
        }

        #endregion

        #region Properties

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public IServiceProvider ServiceProvider { get; set; }

        #endregion

        #region Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DateTime lastImport = DateTime.Now.AddDays(-1);
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime current = DateTime.Now;
                try
                {
                    if (lastImport.Subtract(current).TotalSeconds < -86400)
                    {
                        await ImportCurrencies();
                        await ImportRates();
                        lastImport = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Parceiros: {ex.Message}", ex);
                }

                int.TryParse(_configuration["Settings:TimerInterval"], out int interval);

                await Task.Delay(interval, stoppingToken);
            }
        }

        private async Task ImportCurrencies()
        {
            using var scope = ServiceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICurrencyHandler>();
            await handler.ImportCurrencies();
        }

        private async Task ImportRates()
        {
            using var scope = ServiceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<IRateHandler>();
            await handler.ImportRates();
        }

        #endregion
    }
}
