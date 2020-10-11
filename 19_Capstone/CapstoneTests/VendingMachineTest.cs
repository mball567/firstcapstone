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
        [DataRow(1.00, 1.00)]
        [DataRow(2.00, 2.00)]
        [DataRow(5.00, 5.00)]
        [DataRow(10.00, 10.00)]


        public void FeedMoneyInTest(double moneyFed, double result)
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);

            decimal actual = vendingMachine.FeedMoneyIn(Convert.ToDecimal(moneyFed));

            Assert.AreEqual(Convert.ToDecimal(result), actual);



        }



    }
}
