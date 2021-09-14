using TestShop.Models;

namespace TestShop.Services
{
    public class CartService
    {
        private static readonly CartService _instance = new CartService();

        private readonly ConfigService _configService;

        private readonly uint _cartCapacity;

        static CartService()
        {
        }

        private CartService()
        {
            _configService = ConfigService.Instance;
            _cartCapacity = (uint)_configService.CartCapacity;

            Init();
        }

        public static CartService Instance => _instance;

        public Product[] ProductsInCart { get; set; }

        private void Init()
        {
            ProductsInCart = new Product[_cartCapacity];
        }
    }
}
