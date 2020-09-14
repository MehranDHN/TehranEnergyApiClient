using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TehranEnergyApiClient.Web.ConfigExtension
{
    public static class ConfigurationExtensions
    {
        public static bool IsEnableLoraWANGateway(this IConfiguration config) => config.GetValue<bool>("Features:App:EnableLoraWANGateway");
        public static bool IsEnableExternalPowerSrcApi(this IConfiguration config) => config.GetValue<bool>("Features:App:EnableExternalPowerSrcApi");
        public static string AppTitle(this IConfiguration config) => config.GetValue<string>("Features:HomePage:AppTitle");
    }
}
