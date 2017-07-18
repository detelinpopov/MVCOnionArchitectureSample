using System.Threading.Tasks;
using Interfaces.Core.Services;
using Interfaces.Sql.Entities;
using Interfaces.Sql.Repositories;

namespace Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEmployee> SaveAsync(IEmployee employee)
        {
            var createdEmployee = await _repository.SaveAsync(employee);
            return createdEmployee;
        }

        public async Task<IEmployee> FindAsync(int id)
        {
            var employee = await _repository.FindAsync(id);
            return employee;
        }
    }
}