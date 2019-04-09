using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programForUnitTest
{
    public class BankAccount
    {
        public const string DebitAmountEqualZeroMessage = "Размер вклада не может быть нулевым";
        public const string DebitAmountLessThanZeroMessage = "Размер вклада не может быть отрицательным";

        public string Owner { get; private set; }
        public double DepositPercentage { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(string owner, double beginningBalance, double depositPercentage)
        {
            Owner = owner;
            Balance = beginningBalance;
            DepositPercentage = depositPercentage;
        }

        public void Debit(double amount)
        {
            
            if(amount == 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountEqualZeroMessage);
            }
            
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            Balance += amount;
        }

        public void ChargeInterest()
        {
            Balance += Balance / 100 * DepositPercentage;
        }
    }
}
