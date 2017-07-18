using System;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Sql.Entities;
using NUnit.Framework;
using Sql.Context;
using Sql.Entities;
using Sql.Repositories;

namespace Tester.Sql.Repositories.IntegrationTests
{
    [TestFixture]
    public class EmployeeRepositoryFixture : RepositoryFixture
    {
        private IEmployee CreateEmployee(int index = 1)
        {
            IEmployee employee = new Employee();
            employee.Name = "Test name " + index;
            employee.Email = $"test{index}@test.com";
            employee.ManagerId = index;
            return employee;
        }

        [Test]
        public async Task FindAsync_ReturnsEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            var repository = new EmployeeRepository();

            // Act        
            var savedEmployee = await repository.SaveAsync(employee);

            // Assert
            using (var context = new CodingExerciseContext())
            {
                Assert.IsNotNull(savedEmployee);
                var employeeFromDatabase = context.Employees.FirstOrDefault(e => e.Id == savedEmployee.Id);
                Assert.IsNotNull(employeeFromDatabase);
                Assert.AreEqual(employee.Name, employeeFromDatabase.Name);
                Assert.AreEqual(employee.Email, employeeFromDatabase.Email);
                Assert.AreEqual(employee.ManagerId, employeeFromDatabase.ManagerId);
                Assert.AreEqual(employee.Role, employeeFromDatabase.Role);
            }
        }


        [Test]
        public async Task SaveAsync_SavesEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            var repository = new EmployeeRepository();

            // Act   
            var savedEmployee = await repository.SaveAsync(employee);

            // Assert
            using (var context = new CodingExerciseContext())
            {
                Assert.IsNotNull(savedEmployee);
                var employeeFromDatabase = context.Employees.FirstOrDefault(e => e.Id == savedEmployee.Id);
                Assert.IsNotNull(employeeFromDatabase);
                Assert.AreEqual(employee.Name, employeeFromDatabase.Name);
                Assert.AreEqual(employee.Email, employeeFromDatabase.Email);
                Assert.AreEqual(employee.ManagerId, employeeFromDatabase.ManagerId);
                Assert.AreEqual(employee.Role, employeeFromDatabase.Role);
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public async Task SaveAsync_ThrowsException_IfTheEmployeeIsNotValid()
        {
            // Arrange
            IEmployee employee = null;
            var repository = new EmployeeRepository();

            // Act   
            await repository.SaveAsync(employee);
        }
    }
}