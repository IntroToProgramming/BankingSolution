using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class GoldCustomerTests
    {
        [Theory]
        [InlineData(100, 10)]
        public void GetABonusOnDeposits(decimal amountToDeposit, decimal expectedBonus)
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            account.AccountType = AccountType.Gold;
            // When
            account.Deposit(amountToDeposit);

            // Then
            var expected = openingBalance + amountToDeposit + expectedBonus;
            Assert.Equal(expected, account.GetBalance());
        }
    }
}
