using System.Collections.Generic;
using System.Linq;

namespace Ex2
{
    public static class UserDAO
    {
        public static void AddUser(string login, string password)
        {
            UsersDataBase.Users.Add(new User(login, password));
        }

        public static User GetUser(string login, string password)
        {
            return UsersDataBase.Users.Where(user => user.Login == login).FirstOrDefault(user => user.Password == password);
        }

        public static bool IsUserExist(string login)
        {
            return UsersDataBase.Users.Any(user => user.Login == login);
        }

        public static List<Wallet> GetWallets(User user)
        {
            return user.Wallets;
        }
    }
}