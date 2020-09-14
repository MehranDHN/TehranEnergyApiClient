using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.DTO;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.MapperProfile
{
    public class EnergyProfile : Profile
    {
        public EnergyProfile()
        {
            CreateMap<PowerSrcInfo, PowerSrcInfoDto>().ForMember(dest => dest.buildingId, opt => opt.MapFrom(src => src.TargetCounter != null ? src.TargetCounter.LocationID : 0));
        }
    }
}
