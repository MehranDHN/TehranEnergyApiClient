using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsage.Queries
{
    public class FindPowerUsageQuery : IRequest<PowerSrcUsage>
    {
        public FindPowerUsageQuery(int usageid)
        {
            UsagePkid = usageid;
        }
        public int UsagePkid { get; set; }
    }
}
