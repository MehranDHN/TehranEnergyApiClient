﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TehranEnergyApiClient.Web.Configuration
{
    public class ExternalServicesConfig
    {
        public const string PowerCounterSrcInfo = "PowerCounterSrcInfo";

        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string TokenEndpoint { get; set; }
        public string SaleEndpoint { get; set; }
    }
}
