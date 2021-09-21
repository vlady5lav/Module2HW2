using TestShop.Models;
using TestShop.Providers;

namespace TestShop.Services
{
    public class ProductService
    {
        private readonly ConfigService _configService;
        private readonly ProductProvider _productProvider;

        public ProductService()
        {
            _configService = ConfigService.Instance;
            _productProvider = new ProductProvider();

            Init();
        }

        public Product[] Products { get; private set; }

        private void Init()
        {
            Products = _productProvider.Products;

            Exchange(Products);
        }

        private void Exchange(Product[] products)
        {
            foreach (var product in products)
            {
                var currency = product.Currency;

                switch (currency)
                {
                    case Currency.UAH:
                        break;
                    case Currency.EUR:
                        product.Cost *= _configService.EUR;
                        product.Currency = Currency.UAH;
                        break;
                    case Currency.USD:
                        product.Cost *= _configService.USD;
                        product.Currency = Currency.UAH;
                        break;
                }
            }
        }
    }
}
