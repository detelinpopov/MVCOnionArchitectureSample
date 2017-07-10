using System.Data.Entity;
using System.Threading.Tasks;

using Interfaces.Sql.Context;
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
		{}

		public EmployeeRepository(ICodingExerciseContext context)
		{
			_context = context as CodingExerciseContext;
		}

		public virtual async Task SaveAsync(IEmployee employee)
		{
			Employee employeeAsEntity = employee as Employee;
		    if (employeeAsEntity != null)
		    {
		        _context.Employees.Add(employeeAsEntity);
		        await _context.SaveChangesAsync();
		    }
		}

		public virtual async Task<IEmployee> FindAsync(int id)
		{
			return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
