using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;
using TehranEnergyApiClient.Web.ORM;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Queries
{
    public class PowerUsageV2Handler :
        IRequestHandler<GetPowerUsageV2ListQuery, IEnumerable<PowerSrcUsageV2>>,
        IRequestHandler<GetPowerUsageV2WhereQuery, IEnumerable<PowerSrcUsageV2>>,
        IRequestHandler<FindPowerUsageV2ByTagIDQuery, IEnumerable<PowerSrcUsageV2>>,
        IRequestHandler<FindPowerUsageV2Query, PowerSrcUsageV2>
    {
        private readonly EnergyDbContext _context;
        private readonly IMapper _mapper;
        public PowerUsageV2Handler(EnergyDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<PowerSrcUsageV2>> Handle(GetPowerUsageV2ListQuery request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsageV2.Include(c => c.PowerSource).ToListAsync();
            return powerUsageEntities;
        }
        public async Task<IEnumerable<PowerSrcUsageV2>> Handle(GetPowerUsageV2WhereQuery request, CancellationToken cancellationToken)
        {


            var powerUsageEntities = await _context.PowerSrcUsageV2
                .Where(request.Condition)
                .AsQueryable()
                .Include(c => c.PowerSource).ToListAsync();
            return powerUsageEntities;
        }
        public async Task<IEnumerable<PowerSrcUsageV2>> Handle(FindPowerUsageV2ByTagIDQuery request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsageV2
                .Where(c => c.bill_identifier==request.TagIdentity)
                .AsQueryable()
                .Include(c => c.PowerSource).ToListAsync();
            return powerUsageEntities;
        }
        public async Task<PowerSrcUsageV2> Handle(FindPowerUsageV2Query request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsageV2.Include(c => c.PowerSource).FirstOrDefaultAsync(c => c.Pkid == request.UsagePkid);
            return powerUsageEntities;
        }
    }
}
