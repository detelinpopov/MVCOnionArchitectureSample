using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Interfaces.Sql.Entities;
using Interfaces.Sql.Repositories;
using Sql.Context;
using Sql.Entities;

namespace Sql.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public virtual async Task SaveAsync(IEmployee employee)
        {
            using (CodingExerciseContext context = new CodingExerciseContext())
            {
                Employee employeeAsEntity = employee as Employee;
                if (employeeAsEntity == null)
                {
                    throw new ArgumentException("Invalid Employee.");
                }

                context.Employees.Add(employeeAsEntity);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<IEmployee> FindAsync(int id)
        {
            using (CodingExerciseContext context = new CodingExerciseContext())
            {
                return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}