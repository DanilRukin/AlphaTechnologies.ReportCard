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
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.EmployeeAgregate.Queries
{
    public class GetRangeOfEmployeesQueryHandler : IRequestHandler<GetRangeOfEmployeesQuery, Result<IEnumerable<EmployeeDto>>>
    {
        private AlphaTechnologiesRepordCardDbContext _context;
        private IMapper _mapper;

        public GetRangeOfEmployeesQueryHandler(AlphaTechnologiesRepordCardDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<IEnumerable<EmployeeDto>>> Handle(GetRangeOfEmployeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Employee? employee;
                List<Employee> selectedEmployees = new List<Employee>();
                foreach (var option in request.Options)
                {
                    if (option.IncludeComings && option.IncludeComings)
                    {
                        employee = await _context.Employees
                            .IncludeComings()
                            .IncludePositions()
                            .FirstOrDefaultAsync(e => e.Id == option.Id, cancellationToken);
                    }
                    else if (option.IncludeComings)
                    {
                        employee = await _context.Employees
                            .IncludeComings()
                            .FirstOrDefaultAsync(e => e.Id == option.Id, cancellationToken);
                    }
                    else if (option.IncludePositions)
                    {
                        employee = await _context.Employees
                            .IncludePositions()
                            .FirstOrDefaultAsync(e => e.Id == option.Id, cancellationToken);
                    }
                    else
                    {
                        employee = await _context.Employees
                            .FirstOrDefaultAsync(e => e.Id == option.Id, cancellationToken);
                    }

                    if (employee != null)
                        selectedEmployees.Add(employee);
                }
                return Result.Success(_mapper.Map<List<Employee>, IEnumerable<EmployeeDto>>(selectedEmployees));
            }
            catch (Exception e)
            {
                return ExceptionHandler.Handle<Result<IEnumerable<EmployeeDto>>>(e);
            }
        }
    }
}
