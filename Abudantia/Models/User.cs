namespace Abudantia.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public int? RoleId { get; set; }

        public Role? Role { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
    }
}
