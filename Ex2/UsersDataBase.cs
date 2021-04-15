
using System.Collections.Generic;

namespace Ex2
{
    public static class UsersDataBase
    {
        public static List<User> Users { get; }

        static UsersDataBase()
        {
            Users = new List<User>();
            var user = new User("sys", "sys");
            Users.Add(user);
        }
    }
}