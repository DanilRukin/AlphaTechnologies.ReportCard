using AlphaTechnologies.ReportCard.Domain.ProductionCalendarEntity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.ProductionCalendarEntity
{
    public class ProductionCalendarEntityProductionCalendarDtoProfile : Profile
    {
        public ProductionCalendarEntityProductionCalendarDtoProfile()
        {
            CreateMap<ProductionCalendar, ProductionCalendarDto>()
                .ForMember(dto => dto.Holidays, opt => opt.MapFrom(src => src.Holidays));
        }
    }
}
