using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {
        [Theory]
        [InlineData(100, 10)]
        public void GoldAccountsGetBonusOnDeposit(
            decimal amountToDeposit,
            decimal expectedBonus)
        {
            var account = new GoldAccount();
            var openingBalance = account.GetBalance();


            account.Deposit(amountToDeposit);

            var expected = openingBalance + amountToDeposit + expectedBonus;

            Assert.Equal(expected, account.GetBalance());
           
        }
    }
}
