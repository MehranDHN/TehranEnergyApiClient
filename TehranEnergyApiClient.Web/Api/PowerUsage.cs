using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TehranEnergyApiClient.Web.CQRS.PowerUsage.Queries;

namespace TehranEnergyApiClient.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerUsage : ControllerBase
    {
        private readonly IMediator _mediator;
        public PowerUsage(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("GetPowerUsage/{tagid}")]
        public async Task<IActionResult> GetPowerUsage(string tagid)
        {
            var usageInfo = await _mediator.Send(new FindPowerUsageByTagIDQuery(tagid));
            return Ok(usageInfo);
        }
    }
}
