using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Capstone
{
    public class ProductLoader
    {

        public List<Product> LoadProducts(string filePath)
        {

            filePath = @"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv";

            List<Product> products = new List<Product>();

            using (StreamReader productList = new StreamReader(filePath))
            {
            
                while (!productList.EndOfStream)
                {
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string slotLocation = fields[0];
                    string name = fields[1];
                    decimal price = decimal.Parse(fields[2]);
                    string category = fields[3];
                    Product prod = new Product(slotLocation, name, price, category);
                    products.Add(prod);

                }
            }
            return products;       
        }       

    }
}
