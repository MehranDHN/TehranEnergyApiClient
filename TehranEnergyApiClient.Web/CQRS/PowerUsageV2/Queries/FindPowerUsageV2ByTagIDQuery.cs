using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Queries
{
    public class FindPowerUsageV2ByTagIDQuery : IRequest<IEnumerable<PowerSrcUsageV2>>
    {
        public FindPowerUsageV2ByTagIDQuery(string tagid)
        {
            TagIdentity = tagid;
        }
        public string TagIdentity { get; set; }
    }
}
