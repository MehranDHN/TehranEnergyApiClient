using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.DTO;

namespace TehranEnergyApiClient.Web.CQRS.PowerCounter.Queries
{
    public class GetPowerCounterListQuery : IRequest<IEnumerable<PowerSrcInfoDto>>
    {
    }
}
