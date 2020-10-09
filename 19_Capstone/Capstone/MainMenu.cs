using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu : ConsoleMenu
    {
        private VendingMachine VendingMachine;
        private ProductLoader ProductLoader;

        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;

            AddOption("Display Vending Machine Items", DisplayItems);
            AddOption("Purchase", Purchase);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                cfg.Title = "*** Main Menu ***";
                cfg.ItemForegroundColor = ConsoleColor.Gray;
                cfg.SelectedItemForegroundColor = ConsoleColor.Green;
                cfg.Selector = "==>";
            });
        }

        private MenuOptionResult DisplayItems()
        {
            VendingMachine.GetProductList();
            string[] headings = { "Slot Location", "Product Name", "Price", "Quantity" };

            Console.WriteLine();
            Console.WriteLine("Current Vending Machine Inventory");
            Console.WriteLine();
            Console.WriteLine($"{headings[0],-14} {headings[1],20} {headings[2],6} {headings[3], 10}");
            Console.WriteLine($"{new string('_', 14)} {new string('_', 20)} {new string('_', 6)} {new string('_', 10)} ");

            foreach (Product prod in VendingMachine.Inventory)
            {
                Console.WriteLine($"{prod.SlotLocation, -14} {prod.Name, 20} {prod.Price, 6} {prod.Quantity, 10}");
            }

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
