using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.Web.Services;

namespace TehranEnergyApiClient.Web.Configuration
{
    public static class PowerCounterSrcServiceCollectionExtensions
    {
        public static IServiceCollection AddPowerCounterClientServices(this IServiceCollection services)
        {
            services.AddHttpClient<IPowerCounterSrcApiClient, PowerCounterSrcApiClient>();
            return services;
        }
    }
}
