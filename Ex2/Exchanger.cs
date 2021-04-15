﻿// unset

using System;
using System.Collections.Generic;

namespace Ex2
{
    public class Exchanger
    {
        private static readonly Dictionary<string, double> _rates = new Dictionary<string, double>();

        static Exchanger()
        {
            _rates.Add("EURToUSD", 1.1875);
            _rates.Add("EURToRUB", 90.8588);
            _rates.Add("EURToUAH", 33.0213);
            _rates.Add("EURToCNY", 7.8221);
            
            _rates.Add("USDToEUR", 0.8419);
            _rates.Add("USDToRUB", 75.8212);
            _rates.Add("USDToCNY", 6.5322);
            _rates.Add("USDToUAH", 27.8111);

            _rates.Add("RUBToEUR", 0.0111);
            _rates.Add("RUBToUSD", 0.0131);
            _rates.Add("RUBToUAH", 0.3687);
            _rates.Add("RUBToCNY", 0.0861);

            _rates.Add("UAHToUSD", 0.0363);
            _rates.Add("UAHToEUR", 0.0301);
            _rates.Add("UAHToRUB", 2.7121);
            _rates.Add("UAHToCNY", 0.2336);

            _rates.Add("CNYToRUB", 11.5776);
            _rates.Add("CNYToUAH", 4.2812);
            _rates.Add("CNYToEUR", 0.1278);
            _rates.Add("CNYToUSD", 0.1531);
        }
        public static void Exchange(string firstCode, string secondCode, double money)
        {
            Console.WriteLine(
                _rates.TryGetValue(firstCode.ToUpper() + "To" + secondCode.ToUpper(), out var exchangedMoney)
                    ? $"{money} {firstCode} is {exchangedMoney} {secondCode}"
                    : "Can not exchange the same currencies");
        }
    }
}