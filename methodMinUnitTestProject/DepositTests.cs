using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace programForUnitTest.Tests
{
    [TestClass]
    public class DepositTests
    {
        public static int counter = 1;
        public static Deposit deposit;

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
            deposit = new Deposit("Mr. Bryan Walton", 0, 5);
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
            deposit.Put(debitAmount);

            // Assert
            double actual = deposit.Balance;
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
                deposit.Put(debitAmount);
            }
            // Assert
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Deposit.DebitAmountLessThanZeroMessage);
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
                deposit.Put(debitAmount);
            }
            // Assert
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Deposit.DebitAmountEqualZeroMessage);
                return;
            }

            Assert.Fail("Не происходит проверка на ноль при вкладе");
        }

        [TestMethod]
        public void ChargeInterest_WithValidParameters_UpdatesBalance()
        {
            // Arrange
            double debitAmount = 256.50;
            double expected = 269.3250;

            // Act
            deposit.Put(debitAmount);
            deposit.ChargeInterest();

            // Assert
            double actual = deposit.Balance;
            Assert.AreEqual(expected, actual, "Процент вклада начисляется неверно");
        }
    }
}
