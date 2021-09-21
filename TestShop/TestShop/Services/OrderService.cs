using System;
using TestShop.Models;

namespace TestShop.Services
{
    public class OrderService
    {
        private readonly NotificationService _notificationService;
        private readonly Random _random = new Random();

        public OrderService()
        {
            _notificationService = new NotificationService();
        }

        public Order Order { get; private set; }

        public void CreateOrder(Product[] products, User user)
        {
            if (products == null)
            {
                Console.WriteLine("Error, Products is not defined!");
            }
            else if (user == null)
            {
                Console.WriteLine("Error, User is not defined!");
            }
            else if (user.FirstName == null)
            {
                Console.WriteLine("Error, FirstName is not defined!");
            }
            else if (user.SMS == null && user.Email == null)
            {
                Console.WriteLine("Error, there are NO communication methods (SMS or E-Mail) available!");
            }
            else
            {
                Order = new Order
                {
                    ID = (uint)_random.Next(100, 1000),
                    Products = products,
                    Total = 0
                };

                foreach (var product in products)
                {
                    Order.Total += product.Cost;
                }

                _notificationService.Notify(Order, user);
            }
        }
    }
}
