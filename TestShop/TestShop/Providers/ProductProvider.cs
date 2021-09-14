using System;
using TestShop.Models;

namespace TestShop.Providers
{
    public class ProductProvider
    {
        private const int MinPrice = 1;
        private const int MaxPrice = 10;

        private readonly int _productsTypeCount = Enum.GetNames(typeof(ProductType)).Length;
        private readonly Random _random = new Random();

        public ProductProvider()
        {
            Init();
        }

        public Product[] Products { get; private set; }

        private double RandomDouble(int min, int max)
        {
            return (_random.NextDouble() * (max - min)) + min;
        }

        private void Init()
        {
            ProductType productType;
            Currency currency;

            Products = new Product[_productsTypeCount];

            for (var i = 0; i < _productsTypeCount; i++)
            {
                productType = (ProductType)i;
                currency = (Currency)_random.Next(0, 3);

                Products[i] = new Product() { ID = (uint)i, Name = productType.ToString(), Cost = RandomDouble(MinPrice, MaxPrice), Currency = currency, Quantity = (uint)_random.Next(0, 5) };
            }
        }
    }
}
