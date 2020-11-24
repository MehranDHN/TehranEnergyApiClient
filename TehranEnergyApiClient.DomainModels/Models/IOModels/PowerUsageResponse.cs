using System;
using System.Collections.Generic;
using System.Text;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class PowerUsageResponse
    {
        public string TimeStamp { get; set; }
        public int status { get; set; }
        public string SessionKey { get; set; }
        public string message { get; set; }
        public List<PowerSrcUsageV2> data { get; set; }
    }
}
