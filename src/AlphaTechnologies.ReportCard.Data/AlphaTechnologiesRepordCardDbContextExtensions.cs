using AlphaTechnologies.ReportCard.Domain.DepartmentAgregate;
using AlphaTechnologies.ReportCard.Domain.EmployeeAgregate;
using AlphaTechnologies.ReportCard.Domain.PositionEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTechnologies.ReportCard.Data
{
    public static class AlphaTechnologiesRepordCardDbContextExtensions
    {
        public static IQueryable<Department> IncludeEmployees(this IQueryable<Department> departments)
        {
            return departments.Include(DataConstants.DEPARTMENT_EMPLOYEES);
        }

        public static IQueryable<Employee> IncludePositions(this IQueryable<Employee> employees)
        {
            return employees.Include(DataConstants.EMPLOYEES_POSITIONS);
        }

        public static IQueryable<Employee> IncludeComings(this IQueryable<Employee> employees)
        {
            return employees.Include(DataConstants.EMPLOYEE_COMINGS);
        }

        public static IQueryable<Position> IncludeEmployees(this IQueryable<Position> positions)
        {
            return positions.Include(DataConstants.POSITIONS_EMPLOYEES);
        }
    }
}
