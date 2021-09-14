using TestShop.Configs;

namespace TestShop.Services
{
    public class ConfigService
    {
        private static readonly ConfigService _instance = new ConfigService();

        static ConfigService()
        {
        }

        private ConfigService()
        {
            Init();
            CartCapacity = Config.CartConfig.CartCapacity;
            USD = Config.CurrencyConfig.USD;
            EUR = Config.CurrencyConfig.EUR;
        }

        public static ConfigService Instance => _instance;

        public Config Config { get; private set; }

        public uint? CartCapacity { get; }

        public uint? EUR { get; }

        public uint? USD { get; }

        private void Init()
        {
            Config = new Config()
            {
                CartConfig = new CartConfig()
                {
                    CartCapacity = 10
                },
                CurrencyConfig = new CurrencyConfig()
                {
                    EUR = 31,
                    USD = 27
                }
            };
        }
    }
}
