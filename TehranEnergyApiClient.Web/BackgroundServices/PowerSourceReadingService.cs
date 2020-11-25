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
using TehranEnergyApiClient.DomainModels.Models;
using TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Commands;

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
                    int totalCounter = powerCounters.Count();
                    var processedList = new List<string>();
                    _logger.LogInformation($"Total PowerCounters {totalCounter}");
                    int ccounter = 1;

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        // Cache Not implemented yet
                        foreach (var counter in powerCounters)
                        {
                            if (!processedList.Contains(counter.bill_identifier))
                            {
                                processedList.Add(counter.bill_identifier);
                                // We should extend our Configuration to get this info from there
                                var salesInputModel = new SaleInputModel
                                {
                                    BILL_IDENTIFIER = counter.bill_identifier,
                                    fromyear = 92,
                                    MobileNo = "0999999999"
                                };
                                _logger.LogInformation($"Processing {counter.bill_identifier} current= {ccounter++} from {totalCounter}");
                                // We have our own HttpClient Extension to support extra Authentication scenarios
                                var usageResponse = await powerSourceHttpClient.PostForSalesData(salesInputModel, stoppingToken);
                                // We should send the response to ElasticSearch Repository which is not implemented yet
                                _logger.LogInformation($"Sucessfully recieved {usageResponse.data.Count()} bills Info");
                                foreach (var usageItem in usageResponse.data)
                                {
                                    usageItem.helper_flag = false;
                                    await mediator.Send(new InsertNewUsageV2Command
                                    {
                                        UsageItem = usageItem
                                    });
                                }
                                // Awaitable Request for Payment Info here
                                _logger.LogInformation($"Processing {counter.bill_identifier} compleeted");
                            }
                            else
                            {
                                _logger.LogInformation($"Already Exists {counter.bill_identifier}");
                            }
                        }

                        await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured ", null);
            }
        }
    }
}
