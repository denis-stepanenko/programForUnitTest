using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace programForUnitTest.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        public static int counter = 1;
        public static BankAccount account;

        // Запускается при старте тестирующего класса
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Debug.WriteLine("Подготовка данных для тестирования класса BankAccount");
        }

        // Запускается при старте каждого тестирующего метода
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine($"Запуск теста {counter}");
            counter += 1;
            account = new BankAccount("Mr. Bryan Walton", 0, 5);
        }
        
        // Запускается при завершении каждого тестирующего метода
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("Завершение теста");
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double debitAmount = 4.55;
            double expected = 4.55;
            
            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Аккаунт неправильно считает вклад");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThenZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double debitAmount = -100.00;

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
            double debitAmount = 0;

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
            double debitAmount = 100.00;
            double expected = 105.00;

            // Act
            account.Debit(debitAmount);
            account.ChargeInterest();

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Процент вклада начисляется неверно");
        }
    }
}
