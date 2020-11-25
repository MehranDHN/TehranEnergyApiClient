using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.Web.ORM;

namespace TehranEnergyApiClient.Web.CQRS.PowerUsageV2.Commands
{
    public class PowerUsageV2CommandHandlers : RequestHandler<InsertNewUsageV2Command>
    {
        private readonly EnergyDbContext _context;
        public PowerUsageV2CommandHandlers(EnergyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        protected override void Handle(InsertNewUsageV2Command request)
        {
            var alreadyExists = _context.PowerSrcUsageV2.Any(u =>
            u.bill_identifier == request.UsageItem.bill_identifier &&
            u.sale_year == request.UsageItem.sale_year.Value &&
            u.sale_prd == request.UsageItem.sale_prd.Value);
            if(!alreadyExists)
            {
                _context.PowerSrcUsageV2.Add(request.UsageItem);
                _context.SaveChanges();
                // We need Mediatr Notification Mechanism here.
            }

        }
    }
}
