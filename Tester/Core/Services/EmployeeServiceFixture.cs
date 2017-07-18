using System.Threading.Tasks;
using Core.Services;
using Interfaces.Sql.Entities;
using Moq;
using NUnit.Framework;
using Sql.Entities;
using Sql.Repositories;

namespace Tester.Core.Services
{
    [TestFixture]
    public class EmployeeServiceFixture
    {
        private Mock<EmployeeRepository> _repositoryMock;

        private void SetupRepositoryMock()
        {
            IEmployee employee = CreateEmployee();
            _repositoryMock = new Mock<EmployeeRepository>();
            _repositoryMock.Setup(r => r.SaveAsync(It.IsAny<IEmployee>())).ReturnsAsync(employee);
            _repositoryMock.Setup(r => r.FindAsync(It.IsAny<int>())).ReturnsAsync(employee);
        }

        private IEmployee CreateEmployee(int index = 1)
        {
            IEmployee employee = new Employee();
            employee.Name = "TestName " + index;
            employee.Email = "test@test.com";
            employee.ManagerId = index;
            return employee;
        }

        private bool VerifyEmployee(IEmployee original, IEmployee toCompare)
        {
            Assert.AreEqual(original.Name, toCompare.Name);
            Assert.AreEqual(original.Email, toCompare.Email);
            Assert.AreEqual(original.ManagerId, toCompare.ManagerId);

            return true;
        }

        [Test]
        public async Task FindAsync_CallsRepository()
        {
            // Arrange
            SetupRepositoryMock();
            EmployeeService service = new EmployeeService(_repositoryMock.Object);

            // Act
            await service.FindAsync(1);

            // Assert
            _repositoryMock.Verify(r => r.FindAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task SaveAsync_CallsRepository()
        {
            // Arrange
            IEmployee employee = CreateEmployee();
            SetupRepositoryMock();

            EmployeeService service = new EmployeeService(_repositoryMock.Object);

            // Act
            await service.SaveAsync(employee);

            // Assert
            _repositoryMock.Verify(r => r.SaveAsync(It.IsAny<IEmployee>()), Times.Once);
        }

        [Test]
        public async Task SaveAsync_SendsCorrectObjectToRepository()
        {
            // Arrange
            IEmployee employee = CreateEmployee();
            SetupRepositoryMock();

            EmployeeService service = new EmployeeService(_repositoryMock.Object);

            // Act
            await service.SaveAsync(employee);

            // Assert
            _repositoryMock.Verify(r => r.SaveAsync(It.Is<IEmployee>(e => VerifyEmployee(e, employee))), Times.Once);
        }
    }
}