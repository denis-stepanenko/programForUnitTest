using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace programForUnitTest.Tests
{
    [TestClass]
    public class AssertCollectionTests
    {
        static List<string> employees;
        static List<string> employeesForComparison;

        [ClassInitialize]
        public static void InitializeCurentClass(TestContext context)
        {
            employees = new List<string>();
            employees.Add("Иван");
            employees.Add("Сергей");
            employees.Add("Антон");
            employees.Add("Роман");

            employeesForComparison = new List<string>();
            employeesForComparison.Add("Иван");
            employeesForComparison.Add("Сергей");
            employeesForComparison.Add("Антон");
            employeesForComparison.Add("Роман");
        }

        [TestMethod]
        public void AllItemsAreNotNull()
        {
            CollectionAssert.AllItemsAreNotNull(employees, "Один из элеметов списка возвращает null");
        }

        [TestMethod]
        public void AllItemsAreUnique()
        {
            CollectionAssert.AllItemsAreUnique(employees, "Не все элементы списка являются уникальными");
        }

        [TestMethod]
        public void TwoCollectionsAreEqual()
        {
            CollectionAssert.AreEqual(employees, employeesForComparison, "Списки employees и employeesForComparison отличаются порядком элементов, количеством или значениями элементов");
        }

        [TestMethod]
        public void TwoCollectionsAreEquivalent()
        {
            CollectionAssert.AreEquivalent(employees, employeesForComparison, "Списки employees и employeesForComparison содержат разные элементы");
        }

        [TestMethod]
        public void CollectionConstainsSecondCollection()
        {
            // Arrange
            List<string> employeesForCheckConstains = new List<string>();

            // Act
            employeesForCheckConstains.Add("Антон");
            employeesForCheckConstains.Add("Роман");

            // Assert
            CollectionAssert.IsSubsetOf(employeesForCheckConstains, employees, "Не все элементы списка emploeesForCheckConstains входят в список emploees");
        }

        [TestMethod]
        public void CollectionConstainsElement()
        {
            // Arrange
            string elementForSearch = "Антон";

            // Assert
            CollectionAssert.Contains(employees, elementForSearch, $"Список employees не содержит элемент \"{elementForSearch}\"");
        }

        [TestMethod]
        public void AllElementsInCollectionInstancesOfExpectedType()
        {
            // Arrange
            List<dynamic> strangeCollection = new List<dynamic>();

            // Act
            strangeCollection.Add("Антон");

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(strangeCollection, typeof(string), "Не все элементы списка strangeCollection имеют тип string");
        }
    }
}
