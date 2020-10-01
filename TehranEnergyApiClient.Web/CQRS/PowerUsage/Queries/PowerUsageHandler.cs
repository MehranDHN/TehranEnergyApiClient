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

namespace TehranEnergyApiClient.Web.CQRS.PowerUsage.Queries
{
    public class PowerUsageHandler :
        IRequestHandler<GetPowerUsageListQuery, IEnumerable<PowerSrcUsage>>,
        IRequestHandler<GetPowerUsageWhereQuery, IEnumerable<PowerSrcUsage>>,
        IRequestHandler<FindPowerUsageByTagIDQuery, PowerSrcUsage>,
        IRequestHandler<FindPowerUsageQuery, PowerSrcUsage>
    {
        private readonly EnergyDbContext _context;
        private readonly IMapper _mapper;
        public PowerUsageHandler(EnergyDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<PowerSrcUsage>> Handle(GetPowerUsageListQuery request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsage.Include(c => c.PowerSource).ToListAsync();
            return powerUsageEntities;
        }
        public async Task<IEnumerable<PowerSrcUsage>> Handle(GetPowerUsageWhereQuery request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsage
                .Where(request.Condition)
                .AsQueryable()
                .Include(c => c.PowerSource).ToListAsync();
            return powerUsageEntities;
        }
        public async Task<PowerSrcUsage> Handle(FindPowerUsageByTagIDQuery request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsage.Include(c => c.PowerSource).FirstOrDefaultAsync(c => c.bill_identifier == request.TagIdentity);
            return powerUsageEntities;
        }
        public async Task<PowerSrcUsage> Handle(FindPowerUsageQuery request, CancellationToken cancellationToken)
        {
            var powerUsageEntities = await _context.PowerSrcUsage.Include(c => c.PowerSource).FirstOrDefaultAsync(c => c.Pkid == request.UsagePkid);
            return powerUsageEntities;
        }
    }
}
