using AlphaTechnologies.ReportCard.Application.Services;
using AlphaTechnologies.ReportCard.Data;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.SharedKernel.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetEmployeeByIdQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Employee? employee;
                if (request.Options.IncludeComings && request.Options.IncludePositions)
                {
                    employee = await _context.Employees
                        .IncludePositions()
                        .IncludeComings()
                        .FirstOrDefaultAsync(e => e.Id == request.Options.Id, cancellationToken);
                }
                else if (request.Options.IncludeComings)
                {
                    employee = await _context.Employees
                        .IncludeComings()
                        .FirstOrDefaultAsync(e => e.Id == request.Options.Id, cancellationToken);
                }
                else if (request.Options.IncludePositions)
                {
                    employee = await _context.Employees
                        .IncludePositions()
                        .FirstOrDefaultAsync(e => e.Id == request.Options.Id, cancellationToken);
                }
                else
                {
                    employee = await _context.Employees
                        .FirstOrDefaultAsync(e => e.Id == request.Options.Id, cancellationToken);
                }
                if (employee == null)
                    return Result<EmployeeDto>.NotFound($"No such employee with id: '{request.Options.Id}'");
                else
                    return Result.Success(_mapper.Map<EmployeeDto>(employee));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<EmployeeDto>(e);
            }
        }
    }
}
