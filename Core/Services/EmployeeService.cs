using System.Threading.Tasks;

using Interfaces.Core.Services;
using Interfaces.Sql.Entities;
using Interfaces.Sql.Repositories;

using Sql.Entities;

namespace Core.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _repository;

		public EmployeeService(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public async Task SaveAsync(IEmployee employee)
		{
			await _repository.SaveAsync(employee);
		}

		public async Task<IEmployee> FindAsync(int id)
		{
			IEmployee employee = await _repository.FindAsync(id);
			return employee;
		}
	}
}
