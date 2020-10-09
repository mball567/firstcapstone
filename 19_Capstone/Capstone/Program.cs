using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            // Create and launch the main menu
            MainMenu mainMenu = new MainMenu(vendingMachine);
            mainMenu.Show();

            // Exit the program
            Console.WriteLine("Thanks for buying!");
            Console.ReadKey();
        }
    }
}
