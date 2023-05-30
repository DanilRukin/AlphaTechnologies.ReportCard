using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.PositionEntity
{
    public class PositionEntityPositionDtoProfile : Profile
    {
        public PositionEntityPositionDtoProfile() 
        {
            CreateMap<Position, PositionDto>()
                .ForMember(dto => dto.EmployeesDto, opt => opt.MapFrom(src => src.Emloyees.Select(e => e.Id)));
        }
    }
}
