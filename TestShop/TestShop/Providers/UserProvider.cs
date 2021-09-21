using TestShop.Models;

namespace TestShop.Providers
{
    public class UserProvider
    {
        public UserProvider()
        {
            Init();
        }

        public User User { get; private set; }

        private void Init()
        {
            User = new User()
            {
                FirstName = "Leah",
                LastName = "Gotti",
                Email = "leahgotti@ph.com",
                SMS = +380101010101
            };
        }
    }
}
