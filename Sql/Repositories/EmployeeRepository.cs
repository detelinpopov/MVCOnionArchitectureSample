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
        private readonly CodingExerciseContext _context;

        public EmployeeRepository()
        {
            _context = new CodingExerciseContext();
        }


        public virtual async Task SaveAsync(IEmployee employee)
        {
            var employeeAsEntity = employee as Employee;
            if (employeeAsEntity == null)
                throw new ArgumentException("Invalid Employee.");

            _context.Employees.Add(employeeAsEntity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEmployee> FindAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}