using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.DTO;
using TehranEnergyApiClient.Web.ORM;

namespace TehranEnergyApiClient.Web.CQRS.PowerCounter.Queries
{
    public class PowerCounterHandler
            :
        IRequestHandler<GetPowerCounterListQuery, IEnumerable<PowerSrcInfoDto>>,
        IRequestHandler<GetPowerCounterWhereQuery, IEnumerable<PowerSrcInfoDto>>,
        IRequestHandler<FindPowerCounterQuery, PowerSrcInfoDto>
    {
        private readonly EnergyDbContext _context;
        private readonly IMapper _mapper;
        public PowerCounterHandler(EnergyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PowerSrcInfoDto>> Handle(GetPowerCounterListQuery request, CancellationToken cancellationToken)
        {
            var powerCounterEntities = await _context.PowerSrcInfo.Include(c => c.TargetCounter).ToListAsync();
            List<PowerSrcInfoDto> dtoList = _mapper.Map<List<PowerSrcInfoDto>>(powerCounterEntities);
            return dtoList;
        }
        public async Task<IEnumerable<PowerSrcInfoDto>> Handle(GetPowerCounterWhereQuery request, CancellationToken cancellationToken)
        {
            var powerCounterEntities = await _context.PowerSrcInfo
                .Where(request.Condition)
                .AsQueryable()
                .Include(c => c.TargetCounter)
                .ToListAsync();
            List<PowerSrcInfoDto> dtoList = _mapper.Map<List<PowerSrcInfoDto>>(powerCounterEntities);
            return dtoList;
        }
        public async Task<PowerSrcInfoDto> Handle(FindPowerCounterQuery request, CancellationToken cancellationToken)
        {
            var powerCounterEntity = await _context.PowerSrcInfo.Include(c => c.TargetCounter).FirstOrDefaultAsync(c => c.bill_identifier == request.TagIdentity);
            PowerSrcInfoDto dto = _mapper.Map<PowerSrcInfoDto>(powerCounterEntity);
            return dto;
        }
    }
}
