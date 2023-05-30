using AlphaTechnologies.ReportCard.Domain.ComingEntity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ComingsEntity
{
    public class ComingEntityComingDtoProfile : Profile
    {
        public ComingEntityComingDtoProfile()
        {
            CreateMap<Coming, ComingDto>();
        }
    }
}
