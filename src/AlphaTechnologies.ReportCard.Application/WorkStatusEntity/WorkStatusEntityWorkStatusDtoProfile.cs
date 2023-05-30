using AlphaTechnologies.ReportCard.Domain.WorkStatusEntity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.WorkStatusEntity
{
    public class WorkStatusEntityWorkStatusDtoProfile : Profile
    {
        public WorkStatusEntityWorkStatusDtoProfile()
        {
            CreateMap<WorkStatus, WorkStatusDto>()
                .ForMember(dto => dto.ComingsIds, opt => opt.MapFrom(src => src.Comings.Select(c => c.Id)));
        }
    }
}
