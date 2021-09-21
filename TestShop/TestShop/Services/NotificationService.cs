using System;
using System.Text;
using TestShop.Models;

namespace TestShop.Services
{
    public class NotificationService
    {
        private readonly SmsService _smsService;
        private readonly EmailService _emailService;
        private readonly StringBuilder _stringBuilder;

        public NotificationService()
        {
            _smsService = new SmsService();
            _emailService = new EmailService();
            _stringBuilder = new StringBuilder();
        }

        public void Notify(Order order, User user)
        {
            _stringBuilder.AppendLine($"Dear {user.FirstName} {user.LastName}!");
            _stringBuilder.AppendLine($"Your order #{order.ID} is ready!");
            _stringBuilder.AppendLine($"Total cost: {Math.Round((double)order.Total, 2)} {Currency.UAH}.");
            _stringBuilder.AppendLine($"{Environment.NewLine}Your selected products:");

            foreach (Product product in order.Products)
            {
                _stringBuilder.AppendLine($"{product.Name} - {Math.Round((double)product.Cost, 2)} {product.Currency}");
            }

            string message = _stringBuilder.ToString();

            if (user.SMS != null && user.Email != null)
            {
                Console.WriteLine("Notification via SMS and E-Mail!");
                _smsService.SmsNotification($"{Environment.NewLine}{message}{Environment.NewLine}");
                _emailService.EmailNotification(null);
            }
            else if (user.SMS != null)
            {
                Console.WriteLine("Notification via SMS!");
                _smsService.SmsNotification($"{Environment.NewLine}{message}{Environment.NewLine}");
            }
            else if (user.Email != null)
            {
                Console.WriteLine("Notification via E-Mail!");
                _emailService.EmailNotification($"{Environment.NewLine}{message}{Environment.NewLine}");
            }
        }
    }
}
