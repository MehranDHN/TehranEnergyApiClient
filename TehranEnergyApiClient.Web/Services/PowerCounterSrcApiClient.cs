using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private readonly IOptionsMonitor<ExternalServicesConfig> _optionsDelegate;

        public PowerCounterSrcApiClient(HttpClient httpClient, IOptionsMonitor<ExternalServicesConfig> options, ILogger<PowerCounterSrcApiClient> logger)
        {
            _optionsDelegate = options ?? throw new ArgumentNullException(nameof(options));
            //var externalServiceConfig = options.Get(ExternalServicesConfig.PowerCounterSrcInfo);
            httpClient.BaseAddress = new Uri(_optionsDelegate.CurrentValue.BaseUrl);
            _httpClient = httpClient;
            //_httpClient.SetBearerToken("");
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
                //response.EnsureSuccessStatusCode
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
        private async Task<TokenResponseModel> PostForTokenAsync(string endPointPath, string username, string password, CancellationToken cancellationToken = default)
        {
            try
            {
                TokenCredential tokenCredential = new TokenCredential
                {
                    username = username,
                    password = password
                };
                var serializeCredential = JsonConvert.SerializeObject(tokenCredential);
                var postRequest = new HttpRequestMessage(HttpMethod.Post, endPointPath);
                postRequest.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                postRequest.Content = new StringContent(serializeCredential);
                postRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(postRequest);
                response.EnsureSuccessStatusCode();

                _logger.LogInformation($"API TOKEN Recieve usage call Result Code {response.StatusCode}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"API TOKEN Recieve  usage call is failed");
                    return null;
                }
                var content = await response.Content.ReadAsAsync<TokenResponseModel> (cancellationToken);
                _logger.LogInformation($"API TOKEN Recieve token = {content.data.token}");
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
