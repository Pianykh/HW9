// unset

using System;
using System.Threading;

namespace Ex2
{
    public static class Controller
    {
        private static User _loggedUser;
        public static void ShowMenu()
        {
            while (true) 
            {
                while (_loggedUser == null)
                {
                    Console.WriteLine("Choose action:\n1.Authorization\n2.Registration");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Authorize();
                            break;
                        case "2":
                            Registration();
                            break;
                        case "3":
                            Console.WriteLine("Incorrect command");
                            break;
                    }
                }

                while (_loggedUser != null)
                {
                    Console.WriteLine("Choose action:\n1.Deposit money\n2.Withdraw money\n3.Create wallet\n4.Exchange money.\n5.Logout");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            MakeDeposit();
                            break;

                        case "5":
                            Logout();
                            break;
                    }
                }
            }
        }

        private static void Authorize()
        {
            Console.WriteLine("Please, enter login:");
            var login = Console.ReadLine();
            Console.WriteLine("Please, enter password:");
            var password = Console.ReadLine();

            if (UserDAO.GetUser(login, password) != null)
            {
                _loggedUser = UserDAO.GetUser(login, password);
                Console.WriteLine($"Successful authorization. Welcome, [{login}]");
            }
            else
                Console.WriteLine("Incorrect login or password");
        }

        private static void Registration()
        {
            Console.WriteLine("Please, enter login:");
            var login = Console.ReadLine();
            Console.WriteLine("Please, enter password:");
            var password = Console.ReadLine();

            if (!UserDAO.IsUserExist(login))
                UserDAO.AddUser(login, password);
            else
                Console.WriteLine($"Login [{login}] already exist");
        }

        private static void Logout()
        {
            _loggedUser = null;
        }

        private static void MakeDeposit()
        {
            Console.WriteLine("Choose wallet to make deposit");
            PrintWallets();

        }

        private static void PrintWallets()
        {
            foreach (var wallet in UserDAO.GetWallets(_loggedUser))
                Console.WriteLine($"{UserDAO.GetWallets(_loggedUser).IndexOf(wallet) + 1}.{wallet.Currency}");
        }
    }
}