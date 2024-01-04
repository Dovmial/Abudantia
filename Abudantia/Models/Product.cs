using Abudantia.Enums;

namespace Abudantia.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageLink { get; set; }
        public Enum_CategoryType Category{ get; set; }
    }
}
