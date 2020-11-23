

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

        Task<PowerUsageResponse> GetPowerUsageInfoAsync(SaleInputModel inputModel, CancellationToken cancellationToken = default);
        Task<TokenResponseModel> PostForTokenAsync(string endPointPath, string username, string password, CancellationToken cancellationToken = default);

        Task<PowerUsageResponse> PostForSalesData(SaleInputModel inputModel, CancellationToken cancellationToken = default);
    }
}
