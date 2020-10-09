using MenuFramework;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu : ConsoleMenu
    {
        private VendingMachine vendingMachine;

        public PurchaseMenu(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);

            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                cfg.Title = "*** Purchase Menu ***";
            });
        }

        private MenuOptionResult FeedMoney()
        {
            Console.WriteLine("How much money would you like to feed the machine? $1 $2 $5 or $10 only");
            decimal moneyFed = 0.00M;
            decimal extraMoneyFed = 0.00M;
            moneyFed = decimal.Parse(Console.ReadLine());



            if (moneyFed == 1 || moneyFed == 2 || moneyFed == 5 || moneyFed == 10)
            {
                this.vendingMachine.FeedMoneyIn(moneyFed);
            }
            else
            {
                moneyFed = 0.00M;
                Console.WriteLine("Error: Please enter only $1, $2, $5, or $10");
            }
            
            
            Console.WriteLine($"Current money provided = ${moneyFed} Would you like to add more? (Y/N)");
            string yesOrNo = Console.ReadLine();

            
            while (yesOrNo == "Y" || yesOrNo == "y")
            {
                Console.WriteLine("How much more would you like to add?");
                extraMoneyFed = decimal.Parse(Console.ReadLine());
               
                if (extraMoneyFed == 1 || extraMoneyFed == 2 || extraMoneyFed == 5 || extraMoneyFed == 10)
                {
                    moneyFed += extraMoneyFed;
                    Console.WriteLine($"Current money provided is now = ${moneyFed} Would you like to add more? (Y/N)");
                    yesOrNo = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error: Please enter only $1, $2, $5, or $10");
                    
                }
            }
            if (yesOrNo == "N" || yesOrNo == "n")
            {
                Console.WriteLine("Press enter to return to Purchase Menu");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SelectProduct()
        {
            MainMenu mMenu = new MainMenu(this.vendingMachine);
            mMenu.DisplayItems();

            Console.WriteLine("Please enter the Slot Location of the item you would like to purchase.");

            string sltLocation = Console.ReadLine();

            if (mMenu.CorrectSlotLocations.Contains(sltLocation))
            {

                //loop thru inventory -- if product does not exist, customer is informed. if sold out, customer is informed (retun to purchase menu)

                foreach (Product prod in this.vendingMachine.Inventory)
                {
                    //decrement quant and print name cost and money remaining and message sound
                    if (sltLocation == prod.SlotLocation)
                    {
                        if (prod.Price < this.vendingMachine.Balance)
                        {
                            if (prod.Quantity > 0)
                            {
                                vendingMachine.dispenseItem(prod.SlotLocation);
                                Console.WriteLine($"You just bought: {prod.Name} | Price: ${prod.Price} | You have: ${this.vendingMachine.Balance} remaining.");
                            }
                            if (prod.Quantity < 1)
                            {
                                Console.WriteLine("This product is sold out. Please enter a different slot location.");
                            }
                        }
                        if (prod.Price > this.vendingMachine.Balance)
                        {
                            Console.WriteLine("You did not provide enough money, please feed more money and try again!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Your slot location is incorrect, please try again!");
            }

            List<Product> temp = vendingMachine.Inventory;

            return MenuOptionResult.WaitAfterMenuSelection;
        }
        
    }

}
