// unset

namespace Ex2
{
    public class Wallet
    {
        public string Currency { get; }
        public double AmountOfMoney { get; set; }

        public Wallet(string currency)
        {
            AmountOfMoney = 0;
            Currency = currency;
        }
    }
}