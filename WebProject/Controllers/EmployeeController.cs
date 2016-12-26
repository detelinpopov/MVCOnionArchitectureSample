using System.Collections.Generic;
using System.Web.Mvc;

using Interfaces.Core.TestDataGenerators;
using Interfaces.Sql.Entities;

namespace WebProject.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeDataGenerator _employeeDataGenerator;

		public EmployeeController(IEmployeeDataGenerator employeeDataGenerator)
		{
			_employeeDataGenerator = employeeDataGenerator;
		}

		public ActionResult Index()
		{
			IEnumerable<IEmployee> employees = _employeeDataGenerator.Generate(100);

			return View(employees);
		}
	}
}
