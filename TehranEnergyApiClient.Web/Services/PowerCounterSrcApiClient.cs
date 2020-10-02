using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.DTO;
using TehranEnergyApiClient.DomainModels.Models;
using TehranEnergyApiClient.Web.Configuration;


namespace TehranEnergyApiClient.Web.Services
{
    public class PowerCounterSrcApiClient : IPowerCounterSrcApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PowerCounterSrcApiClient> _logger;

        public PowerCounterSrcApiClient(HttpClient httpClient, IOptionsMonitor<ExternalServicesConfig> options, ILogger<PowerCounterSrcApiClient> logger)
        {
            var externalServiceConfig = options.Get(ExternalServicesConfig.PowerCounterSrcInfo);
            httpClient.BaseAddress = new Uri(externalServiceConfig.Url);
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<PowerSrcInfoDto>> GetPowerCounterSrcInfoAsync(CancellationToken cancellationToken = default)
        {
            const string path = "api/PowerCounter/GetPowerCounters";

            try
            {
                var response = await _httpClient.GetAsync(path, cancellationToken);
                _logger.LogInformation($"API call Result Code {response.StatusCode}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"API call is failed");
                    return null;
                }

                var content = await response.Content.ReadAsAsync<List<PowerSrcInfoDto>>(cancellationToken);

                return content;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Failed to get PowerCounter data from internal API");
            }

            return null;
        }
        public async Task<List<PowerSrcUsage>> GetPowerUsageInfoAsync(string tagid, CancellationToken cancellationToken = default)
        {
            string path = $"api/PowerUsage/GetPowerUsage/{tagid}";

            try
            {
                var response = await _httpClient.GetAsync(path, cancellationToken);
                _logger.LogInformation($"API usage call Result Code {response.StatusCode}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"API usage call is failed");
                    return null;
                }

                var content = await response.Content.ReadAsAsync<List<PowerSrcUsage>>(cancellationToken);

                return content;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Failed to get PowerUsage data from internal API");
            }

            return null;
        }
    }
}
