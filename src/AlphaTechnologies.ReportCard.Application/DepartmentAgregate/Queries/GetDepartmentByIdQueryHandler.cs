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
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Result<DepartmentDto>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetDepartmentByIdQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<DepartmentDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Department? department;
                if (request.Options.IncludeEmployees)
                {
                    department = await _context.Departments
                        .IncludeEmployees()
                        .FirstOrDefaultAsync(d => d.Id == request.Options.DepartmentId, cancellationToken);
                }
                else
                {
                    department = await _context.Departments
                        .FirstOrDefaultAsync(d => d.Id == request.Options.DepartmentId, cancellationToken);
                }
                if (department == null)
                    return Result<DepartmentDto>.NotFound($"No such department with id: '{request.Options.DepartmentId}'");
                else
                    return Result.Success(_mapper.Map<DepartmentDto>(department));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<DepartmentDto>(e);
            }
        }
    }
}
