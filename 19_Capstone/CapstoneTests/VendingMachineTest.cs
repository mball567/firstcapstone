using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(5, 5)]
        [DataRow(10, 10)]


        public void FeedMoneyInTest(decimal moneyFed, decimal result)
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);

            decimal actual = vendingMachine.FeedMoneyIn(moneyFed);

            Assert.AreEqual(result, actual);
        }
        //arrange
        

    }
}
