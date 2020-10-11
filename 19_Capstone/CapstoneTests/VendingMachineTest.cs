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
        [DataRow(7.00, 0.00)]
        [DataRow(-10.00, 0.00)]
        public void FeedMoneyInTest(double moneyFed, double result)
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);

            decimal actual = vendingMachine.FeedMoneyIn(Convert.ToDecimal(moneyFed));

            Assert.AreEqual(Convert.ToDecimal(result), actual);
        }

        [TestMethod]
        public void DispenseItemTestA1()
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);
            vendingMachine.dispenseItem("A1");
            Product expectedProd = new Product("A1", "Potato Crisps", 3.05M, "Chip");
            Product actualProd = new Product("", "", 0, "");
            int expectedQuantity = 4;

            foreach (Product prod in vendingMachine.Inventory)
            {
                if (prod.SlotLocation == "A1")
                {
                    actualProd = prod;
                }
            }

            Assert.AreEqual(expectedProd.SlotLocation, actualProd.SlotLocation);
            Assert.AreEqual(expectedProd.Name, actualProd.Name);
            Assert.AreEqual(expectedProd.Price, actualProd.Price);
            Assert.AreEqual(expectedProd.Category, actualProd.Category);
            Assert.AreEqual(expectedQuantity, actualProd.Quantity);
        }

        [TestMethod]
        public void DispenseItemTestB1()
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);
            vendingMachine.dispenseItem("B1");
            Product expectedProd = new Product("B1", "Moonpie", 1.80M, "Candy");
            Product actualProd = new Product("", "", 0, "");
            int expectedQuantity = 4;

            foreach (Product prod in vendingMachine.Inventory)
            {
                if (prod.SlotLocation == "B1")
                {
                    actualProd = prod;
                }
            }

            Assert.AreEqual(expectedProd.SlotLocation, actualProd.SlotLocation);
            Assert.AreEqual(expectedProd.Name, actualProd.Name);
            Assert.AreEqual(expectedProd.Price, actualProd.Price);
            Assert.AreEqual(expectedProd.Category, actualProd.Category);
            Assert.AreEqual(expectedQuantity, actualProd.Quantity);
        }

        [TestMethod]
        public void DispenseItemTestD1()
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);
            vendingMachine.dispenseItem("D1");
            Product expectedProd = new Product("D1", "U-Chews", 0.85M, "Gum");
            Product actualProd = new Product("", "", 0, "");
            int expectedQuantity = 4;

            foreach (Product prod in vendingMachine.Inventory)
            {
                if (prod.SlotLocation == "D1")
                {
                    actualProd = prod;
                }
            }

            Assert.AreEqual(expectedProd.SlotLocation, actualProd.SlotLocation);
            Assert.AreEqual(expectedProd.Name, actualProd.Name);
            Assert.AreEqual(expectedProd.Price, actualProd.Price);
            Assert.AreEqual(expectedProd.Category, actualProd.Category);
            Assert.AreEqual(expectedQuantity, actualProd.Quantity);
        }

        [TestMethod]
        public void DispenseItemTestWrongSlot()
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);
            vendingMachine.dispenseItem("Z1");
            Product expectedProd = new Product("", "", 0M, "");
            Product actualProd = new Product("", "", 0M, "");
            int expectedQuantity = 5;

            foreach (Product prod in vendingMachine.Inventory)
            {
                if (prod.SlotLocation == "Z1")
                {
                    actualProd = prod;
                }
            }

            Assert.AreEqual(expectedProd.SlotLocation, actualProd.SlotLocation);
            Assert.AreEqual(expectedProd.Name, actualProd.Name);
            Assert.AreEqual(expectedProd.Price, actualProd.Price);
            Assert.AreEqual(expectedProd.Category, actualProd.Category);
            Assert.AreEqual(expectedQuantity, actualProd.Quantity);
        }

        [TestMethod]
        [DataRow(5.00, 20, 0, 0)]
        [DataRow(7.95, 31, 2, 0)]
        [DataRow(5.55, 22, 0, 1)]
        [DataRow(0.15, 0, 1, 1)]
        public void DispenseChangeTest(double expectedBalance, int quarters, int dimes, int nickels)
        {
            ProductLoader productLoader = new ProductLoader();

            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            VendingMachine vendingMachine = new VendingMachine(products);
            vendingMachine.Balance = Convert.ToDecimal(expectedBalance);
            List<int> actualChange = vendingMachine.dispenseChange();
            List<int> expectedChange = new List<int> {quarters, dimes, nickels};

            CollectionAssert.AreEqual(expectedChange, actualChange);

        }
    }
}
