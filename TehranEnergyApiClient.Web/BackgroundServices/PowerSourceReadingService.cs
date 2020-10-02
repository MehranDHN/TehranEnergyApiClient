using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using TehranEnergyApiClient.Web.CQRS.PowerCounter.Queries;
using TehranEnergyApiClient.Web.ORM;
using Microsoft.Extensions.DependencyInjection;
using TehranEnergyApiClient.DomainModels.DTO;
using TehranEnergyApiClient.Web.Services;

namespace TehranEnergyApiClient.Web.BackgroundServices
{
    public class PowerSourceReadingService : BackgroundService
    {
        private readonly ILogger<PowerSourceReadingService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public PowerSourceReadingService(ILogger<PowerSourceReadingService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Started PowerSource reading service.");
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var powerSourceHttpClient = scope.ServiceProvider.GetRequiredService<IPowerCounterSrcApiClient>();
                    var powerCounters = await mediator.Send(new GetPowerCounterListQuery());

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        // Cache Not implemented yet
                        foreach (var counter in powerCounters)
                        {
                            _logger.LogInformation($"Processing {counter.bill_identifier}");
                            // We have our own HttpClient Extension to support extra Authentication scenarios
                            var usageList = await powerSourceHttpClient.GetPowerUsageInfoAsync(counter.bill_identifier, stoppingToken);
                            // We should send the response to ElasticSearch Repository which is not implemented yet
                            _logger.LogInformation($"Sucessfully recieved {usageList.Count()} usage Info");
                            _logger.LogInformation($"Processing {counter.bill_identifier} compleeted");
                            
                        }
                        await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error Occured ", null);
            }
        }
    }
}
