// unset

using System.Collections.Generic;

namespace Ex2
{
    public class User
    {
        public string Login { get; } 
        public string Password { get; }
        public List<Wallet> Wallets = new List<Wallet>();

        public User(string login, string password)
        {
            Wallets.Add(new Wallet("USD"));
            Login = login;
            Password = password;
        }

    }
}