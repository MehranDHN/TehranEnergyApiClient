

using System.Threading;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.DTO;

namespace TehranEnergyApiClient.Web.Services
{
    public interface  IPowerCounterSrcApiClient
    {
        Task<PowerSrcInfoDto> GetPowerCounterSrcInfoAsync(CancellationToken cancellationToken = default);
    }
}
