using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu : ConsoleMenu
    {
        private VendingMachine VendingMachine;
        public List<string> CorrectSlotLocations;

        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;

            AddOption("Display Vending Machine Items", DisplayItems);
            AddOption("Purchase", Purchase);
            AddOption("Exit", Exit);

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

        public MenuOptionResult DisplayItems()
        {
            List<string> correctSlotLocations = new List<string>();

            string[] headings = { "Slot Location", "Product Name", "Price", "Quantity" };

            Console.WriteLine();
            Console.WriteLine("Current Vending Machine Inventory");
            Console.WriteLine();
            Console.WriteLine($"{headings[0],-14} {headings[1],20} {headings[2],6} {headings[3], 10}");
            Console.WriteLine($"{new string('_', 14)} {new string('_', 20)} {new string('_', 6)} {new string('_', 10)} ");

            foreach (Product prod in VendingMachine.Inventory)
            {
                correctSlotLocations.Add(prod.SlotLocation);

                Console.WriteLine($"{prod.SlotLocation, -14} {prod.Name, 20} {prod.Price, 6} {prod.Quantity, 10}");

            }

            CorrectSlotLocations = correctSlotLocations;

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Purchase()
        {
            PurchaseMenu pMenu = new PurchaseMenu(this.VendingMachine);
            pMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
    }
}
