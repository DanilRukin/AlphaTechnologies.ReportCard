using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.DepartmentAgregate
{
    public class DepartmentAgregateDepartmentDtoProfile : Profile
    {
        public DepartmentAgregateDepartmentDtoProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dto => dto.EmployeesIds, opt => opt.MapFrom(src => src.Employees.Select(e => e.Id)))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
