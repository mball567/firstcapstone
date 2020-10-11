using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class ProductLoaderTest
    {
        [TestMethod]
        public void LoadProductsTestForSlotLocation()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            List<Product> products = new List<Product>();

            using (StreamReader productList = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv"))
            {
                //Read through each line
                while (!productList.EndOfStream)
                {
                    //Assign properties of each product which are delimited by the | symbol
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string slotLocation = fields[0];
                    string name = fields[1];
                    decimal price = decimal.Parse(fields[2]);
                    string category = fields[3];

                    //Create a new product and add it to the product list
                    Product pd = new Product(slotLocation, name, price, category);
                    products.Add(pd);

                }
            }

            //act 

            List<Product> actual = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");


            //assert
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(products[i].SlotLocation, actual[i].SlotLocation);
            }
        }

        [TestMethod]
        public void LoadProductsTestForName()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            List<Product> products = new List<Product>();

            using (StreamReader productList = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv"))
            {
                //Read through each line
                while (!productList.EndOfStream)
                {
                    //Assign properties of each product which are delimited by the | symbol
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string slotLocation = fields[0];
                    string name = fields[1];
                    decimal price = decimal.Parse(fields[2]);
                    string category = fields[3];

                    //Create a new product and add it to the product list
                    Product pd = new Product(slotLocation, name, price, category);
                    products.Add(pd);

                }
            }

            //act 

            List<Product> actual = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");


            //assert
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(products[i].Name, actual[i].Name);
            }
        }

        [TestMethod]
        public void LoadProductsTestForPrice()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            List<Product> products = new List<Product>();

            using (StreamReader productList = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv"))
            {
                //Read through each line
                while (!productList.EndOfStream)
                {
                    //Assign properties of each product which are delimited by the | symbol
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string slotLocation = fields[0];
                    string name = fields[1];
                    decimal price = decimal.Parse(fields[2]);
                    string category = fields[3];

                    //Create a new product and add it to the product list
                    Product pd = new Product(slotLocation, name, price, category);
                    products.Add(pd);

                }
            }

            //act 

            List<Product> actual = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");


            //assert
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(products[i].Price, actual[i].Price);
            }
        }

        [TestMethod]
        public void LoadProductsTestForCategory()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            List<Product> products = new List<Product>();

            using (StreamReader productList = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv"))
            {
                //Read through each line
                while (!productList.EndOfStream)
                {
                    //Assign properties of each product which are delimited by the | symbol
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string slotLocation = fields[0];
                    string name = fields[1];
                    decimal price = decimal.Parse(fields[2]);
                    string category = fields[3];

                    //Create a new product and add it to the product list
                    Product pd = new Product(slotLocation, name, price, category);
                    products.Add(pd);

                }
            }

            //act 

            List<Product> actual = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");


            //assert
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(products[i].Category, actual[i].Category);
            }
        }

        [TestMethod]
        public void LoadProductsTestForQuantity()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            List<Product> products = new List<Product>();

            using (StreamReader productList = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv"))
            {
                //Read through each line
                while (!productList.EndOfStream)
                {
                    //Assign properties of each product which are delimited by the | symbol
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string slotLocation = fields[0];
                    string name = fields[1];
                    decimal price = decimal.Parse(fields[2]);
                    string category = fields[3];

                    //Create a new product and add it to the product list
                    Product pd = new Product(slotLocation, name, price, category);
                    products.Add(pd);

                }
            }

            //act 

            List<Product> actual = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");
            int actualQuantity = 5;

            //assert
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(actualQuantity, actual[i].Quantity);
            }
        }
    }
}
