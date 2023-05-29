using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate
{
    public class EmployeeAgregateEmployeeDtoProfile : Profile
    {
        public EmployeeAgregateEmployeeDtoProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.PersonalData.FirstName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.PersonalData.LastName))
                .ForMember(dto => dto.Patronymic, opt => opt.MapFrom(src => src.PersonalData.Patronymic))
                .ForMember(dto => dto.ServiceNumber, opt => opt.MapFrom(src => src.ServiceNumber.Value))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(src => src.Address.Value))
                .ForMember(dto => dto.ComingDaysIds, opt => opt.MapFrom(src => src.Comings.Select(c => c.Id)))
                .ForMember(dto => dto.PositionsIds, opt => opt.MapFrom(src => src.Positions.Select(p => p.Id)))
                ;
        }
    }
}
