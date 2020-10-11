using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu : ConsoleMenu
    {
        //Main menu has 2 properties, a vending machine, and a list of correct slot locations
        private VendingMachine VendingMachine;
        public List<string> CorrectSlotLocations;

        //Constructor for main menu that is passed in a vending machine
        public MainMenu(VendingMachine vendingMachine)
        {
            //Passed in vending machine is assigned to this VendingMachine
            VendingMachine = vendingMachine;

            //Add display items, purchase, and exit menus to main menu
            AddOption("Display Vending Machine Items", DisplayItems);
            AddOption("Purchase", Purchase);
            AddOption("Exit", Exit);

            //Configure visuals of menu
            Configure(cfg =>
            {
                cfg.Title = "*** Main Menu ***";
                cfg.ItemForegroundColor = ConsoleColor.Blue;
                cfg.SelectedItemForegroundColor = ConsoleColor.White;
                cfg.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
                cfg.Selector = ">> ";
                cfg.BeepOnError = true;
            });
        }

        //Make a menu option result DisplayItems method that prints out the current inventory of products neatly
        public MenuOptionResult DisplayItems()
        {
            //Make a new list of slot locations so we can call on this method to later verify if slot loaction input is valid
            List<string> correctSlotLocations = new List<string>();

            //Format rows
            string[] headings = { "Slot Location", "Product Name", "Price", "Quantity" };

            Console.WriteLine();
            Console.WriteLine("Current Vending Machine Inventory");
            Console.WriteLine();
            Console.WriteLine($"{headings[0],-14} {headings[1],20} {headings[2],6} {headings[3], 10}");
            Console.WriteLine($"{new string('_', 14)} {new string('_', 20)} {new string('_', 6)} {new string('_', 10)} ");

            //Loop through all products in inventory
            foreach (Product prod in VendingMachine.Inventory)
            {
                //Add every products slot location into correct slot locations list
                correctSlotLocations.Add(prod.SlotLocation);

                //Print out each propucts properties
                Console.WriteLine($"{prod.SlotLocation, -14} {prod.Name, 20} {prod.Price, 6} {prod.Quantity, 10}");

            }

            //Constructor for correct slot locations
            CorrectSlotLocations = correctSlotLocations;

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        //Show purchase menu
        private MenuOptionResult Purchase()
        {
            PurchaseMenu pMenu = new PurchaseMenu(this.VendingMachine);
            pMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
    }
}
