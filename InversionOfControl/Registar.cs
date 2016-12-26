using System.Web.Mvc;

using Core.Services;
using Core.TestDataGenerators;

using Interfaces.Core.Services;
using Interfaces.Core.TestDataGenerators;
using Interfaces.Sql.Context;
using Interfaces.Sql.Entities;
using Interfaces.Sql.Repositories;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

using Sql.Context;
using Sql.Entities;
using Sql.Repositories;

namespace InversionOfControl
{
	public class Registar
	{
		public static void Start()
		{
			IUnityContainer container = BuildUnityContainer();
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}

		private static IUnityContainer BuildUnityContainer()
		{
			UnityContainer container = new UnityContainer();

			container.BindInRequestScope<ICodingExerciseContext, CodingExerciseContext>();

			container.BindInRequestScope<IEmployee, Employee>();
			container.BindInRequestScope<IEmployeeRepository, EmployeeRepository>();
			container.BindInRequestScope<IEmployeeService, EmployeeService>();

			container.BindInRequestScope<IEmployeeDataGenerator, EmployeeDataGenerator>();

			return container;
		}
	}
}
