

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.DTO;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.Services
{
    public interface  IPowerCounterSrcApiClient
    {
        Task<List<PowerSrcInfoDto>> GetPowerCounterSrcInfoAsync(CancellationToken cancellationToken = default);

        Task<List<PowerSrcUsage>> GetPowerUsageInfoAsync(string tagid,CancellationToken cancellationToken = default);
    }
}
