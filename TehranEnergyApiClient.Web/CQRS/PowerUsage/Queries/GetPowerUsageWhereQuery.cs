using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsage.Queries
{
    public class GetPowerUsageWhereQuery : IRequest<IEnumerable<PowerSrcUsage>>
    {
        public GetPowerUsageWhereQuery(Func<PowerSrcUsage, bool> condition)
        {
            Condition = condition;
        }
        public Func<PowerSrcUsage, bool> Condition { get; set; }
    }
}
