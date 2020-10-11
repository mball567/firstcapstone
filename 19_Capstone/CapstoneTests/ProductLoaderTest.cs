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
        public void LoadProductsTest()
        {
            //arrange
            ProductLoader pLoader = new ProductLoader();
            List<Product> pducts = new List<Product>();

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
                    pducts.Add(pd);

                }
            }

            //act 

            List<Product> actual = pLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");


            //assert

            CollectionAssert.AreEquivalent(pducts, actual);
            
            
            
            
            
            //{
            //     //arrange
            //    ProductLoader productLoader = new ProductLoader();
            //    //act
            //    List<Product> actual = productLoader.LoadProducts(filePath);
            //    //assert
            //    Assert.AreEqual(resultList, actual);
            //}
        }
    }
}
