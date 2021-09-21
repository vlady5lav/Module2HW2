using TestShop.Models;
using TestShop.Providers;

namespace TestShop.Services
{
    public class UserService
    {
        private readonly UserProvider _userProvider;

        public UserService()
        {
            _userProvider = new UserProvider();

            Init();
        }

        public User User { get; private set; }

        private void Init()
        {
            User = _userProvider.User;
        }
    }
}
