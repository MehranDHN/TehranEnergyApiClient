using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TehranEnergyApiClient.Web.CQRS.PowerCounter.Queries;
using TehranEnergyApiClient.Web.Models;
using TehranEnergyApiClient.Web.ORM;

namespace TehranEnergyApiClient.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EnergyDbContext _context;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, EnergyDbContext context, IMediator mediator)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IActionResult> Index()
        {
            var counters = await _mediator.Send(new GetPowerCounterListQuery());
            //var data = _context.PowerSrcInfo.Include(ps => ps.UsageDetails).ToList();
            //_logger.LogInformation($"PowerSource Count {data.Count}");
            //_logger.LogInformation($"PowerSource Count {counters.Count()}");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
