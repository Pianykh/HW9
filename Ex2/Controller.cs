// unset

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                        case "2":
                            MakeWithdraw();
                            break;
                        case "3":
                            CreateWallet();
                            break;
                        case "4":
                            Exchange();
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
                Thread.Sleep(1000);
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
            var wallet = ChooseWallet();
            Console.WriteLine("Enter amount of money:");

            while (true)
                if (double.TryParse(Console.ReadLine(), out var money))
                {
                    wallet.AmountOfMoney += money;
                    Console.WriteLine("Successfully deposit");
                    break;
                }
                else
                    Console.WriteLine("Incorrect amount. Try again");
        }

        private static void PrintWallets()
        {
            foreach (var wallet in UserDAO.GetWallets(_loggedUser))
                Console.WriteLine($"{UserDAO.GetWallets(_loggedUser).IndexOf(wallet) + 1}.{wallet.Currency}");
        }

        private static void MakeWithdraw()
        {
            var wallet = ChooseWallet();
            Console.WriteLine($"You have {wallet.AmountOfMoney} {wallet.Currency}");
            Console.WriteLine("Enter amount of money:");

            while (true)
                if (double.TryParse(Console.ReadLine(), out var money))
                {
                    if (money <= wallet.AmountOfMoney)
                    {
                        wallet.AmountOfMoney += money;
                        Console.WriteLine("Successfully withdraw");
                        break;
                    }
                    Console.WriteLine("Not enough money. Try again");
                }
                else
                    Console.WriteLine("Incorrect amount. Try again");
        }

        private static Wallet ChooseWallet()
        {
            PrintWallets();
            Wallet wallet = null;
            
            while (wallet == null)
                switch (Console.ReadLine())
                {
                    case "1":
                        wallet = _loggedUser.Wallets[0];
                        break;
                    case "2" when _loggedUser.Wallets.Count > 1:
                        wallet = _loggedUser.Wallets[1];
                        break;
                    case "3" when _loggedUser.Wallets.Count > 2:
                        wallet = _loggedUser.Wallets[2];
                        break;
                    case "4" when _loggedUser.Wallets.Count > 3:
                        wallet = _loggedUser.Wallets[3];
                        break;
                    case "5" when _loggedUser.Wallets.Count > 4:
                        wallet = _loggedUser.Wallets[4];
                        break;
                    default:
                        Console.WriteLine("Enter number of wallet");
                        break;
                }
            return wallet;
        }

        private static void CreateWallet()
        {
            var availableCurrencies = new List<string>() { "USD", "EUR", "UAH", "RUB", "CNY" };
            Console.WriteLine("Choose currency to create wallet");
            foreach (var wallet in _loggedUser.Wallets.Where(wallet => availableCurrencies.Contains(wallet.Currency)))
                availableCurrencies.Remove(wallet.Currency);
            foreach (var currency in availableCurrencies)
                Console.WriteLine($"{availableCurrencies.IndexOf(currency) + 1}.{currency}");
            while (true)
                if (int.TryParse(Console.ReadLine(), out var command) && command <= availableCurrencies.Count)
                {
                    _loggedUser.Wallets.Add(new Wallet(availableCurrencies[command - 1]));
                    Console.WriteLine($"{availableCurrencies[command - 1]} wallet was created");
                    break;
                }
                else
                    Console.WriteLine("Incorrect command. Try again");
        }

        private static void Exchange()
        {
            Console.WriteLine("Select the wallet whose currency you want to change");
            var sellCurrencyWallet = ChooseWallet();
            Console.WriteLine("Select the wallet for which you want to change the currency");
            var buyCurrencyWallet = ChooseWallet();
            Console.WriteLine($"You have {sellCurrencyWallet.AmountOfMoney} {sellCurrencyWallet.Currency}");
            Console.WriteLine($"{sellCurrencyWallet.Currency} to {buyCurrencyWallet.Currency} rate " +
                              $"is {Exchanger.GetRate(sellCurrencyWallet.Currency, buyCurrencyWallet.Currency)}");
            Console.WriteLine("Enter amount of money:");
            while (true)
                if (double.TryParse(Console.ReadLine(), out var money))
                {
                    if (money <= sellCurrencyWallet.AmountOfMoney)
                    {
                        Exchanger.Exchange(sellCurrencyWallet, buyCurrencyWallet, money);
                        break;
                    }
                    Console.WriteLine("Not enough money. Try again");
                }
                else
                    Console.WriteLine("Incorrect amount. Try again");
        }
    }
}