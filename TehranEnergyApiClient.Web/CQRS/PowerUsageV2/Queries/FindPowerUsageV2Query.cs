using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Queries
{
    public class FindPowerUsageV2Query : IRequest<PowerSrcUsageV2>
    {
        public FindPowerUsageV2Query(int usageid)
        {
            UsagePkid = usageid;
        }
        public int UsagePkid { get; set; }
    }
}
