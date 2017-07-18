using Interfaces.Sql.Entities;

namespace Sql.Entities
{
    public class Employee : IEmployee
    {
        public string Email { get; set; }

        public int Id { get; set; }

        public int? ManagerId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}