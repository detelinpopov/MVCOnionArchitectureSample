using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Interfaces.Sql.Context;

using Sql.Entities;

namespace Sql.Context
{
	public class CodingExerciseContext : DbContext, ICodingExerciseContext
	{
		public CodingExerciseContext()
			: base("CodingExerciseContext")
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<CodingExerciseContext>());
		}

		public DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
