using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new product loader, and load products from a text file
            ProductLoader productLoader = new ProductLoader();
            List<Product> products = productLoader.LoadProducts(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv");

            //Create a new vending machine
            VendingMachine vendingMachine = new VendingMachine(products);

            // Create and launch the main menu
            MainMenu mainMenu = new MainMenu(vendingMachine);
            mainMenu.Show();

            // Exit the program
            Console.WriteLine("Thanks for buying!");
            Console.ReadKey();
        }
    }
}
