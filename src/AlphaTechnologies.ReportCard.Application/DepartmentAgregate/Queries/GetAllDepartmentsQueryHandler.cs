using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, Result<IEnumerable<DepartmentDto>>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetAllDepartmentsQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<IEnumerable<DepartmentDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Department>? departments;
                if (request.IncludeEmployees)
                {
                    departments = await _context.Departments.IncludeEmployees().ToListAsync(cancellationToken);
                }
                else
                {
                    departments = await _context.Departments.ToListAsync(cancellationToken);
                }
                if (departments == null)
                    return Result<IEnumerable<DepartmentDto>>.NotFound("No departments in database");
                return Result.Success(departments.Select(d => _mapper.Map<DepartmentDto>(d)));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<IEnumerable<DepartmentDto>>(e);
            }
        }
    }
}
