namespace Abudantia.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageLink { get; set; }
        public int Amount { get; set; }

        public ICollection<Order> Orders { get; set; } = [];
        public override string ToString() => $"{Name}: {Price}";
    }
}
