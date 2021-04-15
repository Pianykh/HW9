
using System;

namespace Ex1
{
    public static class GreatRandom
    {
        private static readonly Random _random = new Random();

        public static int GenerateDamage()
        {
            return _random.Next(5, 26);
        }

        public static int GenerateMove()
        {
            return _random.Next(0, 2);
        }
    }
}