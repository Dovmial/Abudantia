

using System.ComponentModel.DataAnnotations.Schema;

namespace Abudantia.Models
{
    //Списки прдуктов
    public class OrdersProducts
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }


        public Product Product { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}
