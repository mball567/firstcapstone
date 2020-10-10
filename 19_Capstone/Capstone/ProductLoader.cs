using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Capstone
{
    public class ProductLoader
    {
        //Make load products method that reads each line from a text file and returns a list of all the products in the file
        public List<Product> LoadProducts(string filePath)
        {

            //Make a new list of products
            List<Product> products = new List<Product>();

            //Read from text file at passed in file path
            using (StreamReader productList = new StreamReader(filePath))
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
                    Product prod = new Product(slotLocation, name, price, category);
                    products.Add(prod);

                }
            }
            //Return list of products
            return products;       
        }       
    }
}
