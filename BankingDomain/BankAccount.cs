using System;

namespace BankingDomain
{
    public enum AccountType {  Standard, Gold }
    public class BankAccount
    {
        private decimal _balance = 5000; // Class Variable "Field"
        public AccountType AccountType = AccountType.Standard;
        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = 0;
            if(AccountType == AccountType.Gold)
            {
                bonus = amountToDeposit * .10M;
            }
            _balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
    }
}