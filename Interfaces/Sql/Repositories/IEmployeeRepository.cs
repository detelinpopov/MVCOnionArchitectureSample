using System.Threading.Tasks;

using Interfaces.Sql.Entities;

namespace Interfaces.Sql.Repositories
{
	public interface IEmployeeRepository
	{
		Task<IEmployee> FindAsync(int id);

		Task<IEmployee> SaveAsync(IEmployee employee);
	}
}
