using System;
using System.Collections.Generic;

using Interfaces.Core.TestDataGenerators;
using Interfaces.Sql.Entities;

using Sql.Entities;

namespace Core.TestDataGenerators
{
	public class EmployeeDataGenerator : IEmployeeDataGenerator
	{
		public IEnumerable<IEmployee> Generate(int count)
		{
			IList<IEmployee> employees = new List<IEmployee>();
			IList<string> roles = new List<string> { "Developer", "QA", "Manager", "Support" };
			Random random = new Random();

			for (int i = 0; i < count; i++)
			{
				IEmployee employee = new Employee();
				employee.Id = i + 1;
				employee.Name = "Fake employee " + (i + 1);
				employee.Email = $"fake_employee_{i + 1}@test.com";
				employee.Role = roles[random.Next(0, roles.Count)];

				employees.Add(employee);
			}

			return employees;
		}
	}
}
