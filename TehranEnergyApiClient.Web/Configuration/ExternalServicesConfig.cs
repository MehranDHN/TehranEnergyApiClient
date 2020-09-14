using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TehranEnergyApiClient.Web.Configuration
{
    public class ExternalServicesConfig
    {
        public const string PowerApi = "PowerApi";
        public const string WaterApi = "WaterApi";
        public const string GasApi = "GasApi";
        public const string PowerCounterSrcInfo = "PowerCounterSrcInfo";

        public string Url { get; set; }
        public int MinsToCache { get; set; }
        public string ApiKey { get; set; }
    }
}
