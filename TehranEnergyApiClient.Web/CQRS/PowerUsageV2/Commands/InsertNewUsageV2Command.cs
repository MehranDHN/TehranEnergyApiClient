﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Commands
{
    public class InsertNewUsageV2Command : IRequest
    {
        public PowerSrcUsageV2 UsageItem { get; set; }
    }
}
