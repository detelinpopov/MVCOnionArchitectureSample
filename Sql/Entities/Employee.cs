using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Interfaces.Sql.Entities;

namespace Sql.Entities
{
	public class Employee : IEmployee
	{
		public int Age { get; set; }

		public string Email { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public int? ManagerId { get; set; }

		public string Name { get; set; }

		public string Role { get; set; }

		public string SurName { get; set; }

		public List<string> Teams { get; set; }
	}
}
