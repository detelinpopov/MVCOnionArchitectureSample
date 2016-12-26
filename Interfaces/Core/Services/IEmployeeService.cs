using System.Threading.Tasks;

using Interfaces.Sql.Entities;

namespace Interfaces.Core.Services
{
	public interface IEmployeeService
	{
		IEmployee CreateNewObject();

		Task<IEmployee> FindAsync(int id);

		Task SaveAsync(IEmployee employee);
	}
}
