namespace Interfaces.Sql.Entities
{
	public interface IEmployee
	{
		string Email { get; set; }

		int Id { get; set; }

		int? ManagerId { get; set; }

		string Name { get; set; }

		string Role { get; set; }
	}
}
