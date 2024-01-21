using Abudantia.Helpers.Enums;

namespace Abudantia.Models
{
    public class Order
    {
        
        public Guid OrderId { get; set; }
        public int? UserId { get; set; }
        public Enum_OderStatus OrderStatus { get; set; }
        public DateTime TimeStamp { get; set; }

        //навигационные поля
        public User? User { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}
