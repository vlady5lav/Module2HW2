using System;
using TestShop.Models;
using TestShop.Services;

namespace TestShop
{
    public class Starter
    {
        private readonly ConfigService _configService;
        private readonly CartService _cartService;
        private readonly ProductService _productService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly uint _cartCapacity;
        private readonly User _user;
        private readonly Random _random = new Random();

        public Starter()
        {
            _configService = ConfigService.Instance;
            _cartService = CartService.Instance;
            _productService = new ProductService();
            _userService = new UserService();
            _user = _userService.User;
            _orderService = new OrderService();
            _cartCapacity = (uint)_configService.CartCapacity;
        }

        public void Run()
        {
            var products = _productService.Products;

            PickProduct(products, _cartCapacity);

            _orderService.CreateOrder(_cartService.ProductsInCart, _user);
        }

        public void PickProduct(Product[] products, uint cartCapacity)
        {
            for (var i = 0; i < cartCapacity; i++)
            {
                var randomIndex = _random.Next(0, products.Length);

                if (products[randomIndex].Quantity > 0)
                {
                    products[randomIndex].Quantity -= 1;
                    var pickedProduct = products[randomIndex];
                    _cartService.ProductsInCart[i] = pickedProduct;
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
