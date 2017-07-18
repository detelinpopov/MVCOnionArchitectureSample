using System.Threading.Tasks;
using Interfaces.Sql.Entities;

namespace Interfaces.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEmployee> FindAsync(int id);

        Task<IEmployee> SaveAsync(IEmployee employee);
    }
}