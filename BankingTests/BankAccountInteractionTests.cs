using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class BankAccountInteractionTests
    {
        [Fact]
        public void DepositUsesTheBonusCalculator()
        {
            // Given
            var stubbedBonusCalculator = new StubbedBonusCalculator();
            var account = new BankAccount(stubbedBonusCalculator);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 10M;
            stubbedBonusCalculator.AmountToReturn = 42;
            stubbedBonusCalculator.ExpectedAmountOfDeposit = amountToDeposit;
            stubbedBonusCalculator.ExpectedBalance = openingBalance;


            // When
            account.Deposit(amountToDeposit);
            /// Then
            Assert.Equal(
                openingBalance +
                amountToDeposit +
                42, account.GetBalance());
            
        }
    }

    public class StubbedBonusCalculator : ICanCalculateBankAccountBonuses
    {
        public decimal ExpectedBalance;
        public decimal ExpectedAmountOfDeposit;
        public decimal AmountToReturn;
        public decimal For(decimal balance, decimal amountToDeposit)
        {
           if(balance == ExpectedBalance && 
                amountToDeposit == ExpectedAmountOfDeposit)
            {
                return AmountToReturn;
            } else
            {
                return -10; // something dumb.
            }
        }
    }
}
