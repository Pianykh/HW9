using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Tests
{
    public class ExchangerTests
    {
        [Theory]
        [InlineData("UAH", "RUB", 2.7121)]
        [InlineData("EUR", "USD", 1.1875)]
        [InlineData("EUR", "RUB", 90.8588)]
        public void GetRate_ShouldReturnRate(string firstCurrency, string secondCurrency, double expectedRate)
        {
            var actualRate = Exchanger.GetRate(firstCurrency, secondCurrency);

            Assert.Equal(expectedRate, actualRate);
        }
    }
}
