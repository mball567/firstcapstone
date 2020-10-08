using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class ProductLoader
    {
        public static IEnumerable<Product> LoadProducts(string filePath)
        {
            using (StreamReader productList = new StreamReader(filePath))
            {
                while (!productList.EndOfStream)
                {
                    string input = productList.ReadLine();
                    string[] fields = input.Split("|");
                    string productName = fields[0];
                    decimal price = decimal.Parse(fields[1]);
                    string category = fields[2];
                    Product prod = new Product(productName, price, category);
                    products.Add(prod);
                }
            }
        }
    }
}
