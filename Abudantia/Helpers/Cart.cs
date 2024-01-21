using Abudantia.Models;

namespace Abudantia.Helpers
{
    public class Cart
    {
        private Dictionary<Product, int> _choosedGoods = new();
        public decimal TotalPrice { get; private set; } = 0m;
        public void Add(Product product, int amount = 1)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            if (_choosedGoods.ContainsKey(product))
                _choosedGoods[product] += amount;
            else
                _choosedGoods.Add(product, amount);
            TotalPrice += product.Price * amount;
        }

        public void Remove(Product product)
        {
            if (_choosedGoods.ContainsKey(product))
            {
                TotalPrice -= product.Price * _choosedGoods[product];
                _choosedGoods.Remove(product);

            }
        }

        public int this[Product product]
        {
            get => _choosedGoods[product];
            set => _choosedGoods[product] = value;
        }

        public bool ContainsGoodByID(Product product) => _choosedGoods.ContainsKey(product);
        public int Count => _choosedGoods.Count;
    }
}
