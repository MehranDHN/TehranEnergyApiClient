using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Queries
{
    public class GetPowerUsageV2WhereQuery : IRequest<IEnumerable<PowerSrcUsageV2>>
    {
        public GetPowerUsageV2WhereQuery(Func<PowerSrcUsageV2, bool> condition)
        {
            Condition = condition;
        }
        public Func<PowerSrcUsageV2, bool> Condition { get; set; }
    }
}
