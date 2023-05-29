using AlphaTechnologies.ReportCard.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Application.DepartmentAgregate.Queries
{
    public class GetAllDepartmentsQuery : IRequest<Result<IEnumerable<DepartmentDto>>>
    {
        public bool IncludeEmployees { get; }

        public GetAllDepartmentsQuery(bool includeEmployees)
        {
            IncludeEmployees = includeEmployees;
        }
    }
}
