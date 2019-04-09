using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace programForUnitTest.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance, 5);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0, "Аккаунт неправильно считает вклад");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThenZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance, 5);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            // Assert
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("Не происходит проверка на отрицательные значения при вкладе");
        }

        [TestMethod]
        public void Debit_WhenAmountEqualZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 15.00;
            double debitAmount = 0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance, 5);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            // Assert
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountEqualZeroMessage);
                return;
            }

            Assert.Fail("Не происходит проверка на ноль при вкладе");
        }

        [TestMethod]
        public void ChargeInterest_WithValidParameters_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 90.00;
            double debitAmount = 10.00;
            double depositPercentage = 5.00;
            double expected = 105.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance, depositPercentage);

            // Act
            account.Debit(debitAmount);
            account.ChargeInterest();

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0, "Процент вклада начисляется неверно");
        }
    }
}
