using MenuFramework;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu : ConsoleMenu
    {
        //Only property is a vending machine
        private VendingMachine vendingMachine;

        //Constructor for purchase menu that is passed in a vending machine
        public PurchaseMenu(VendingMachine vendingMachine)
        {
            //Assign this.vendingmachine to the passed in vending machine
            this.vendingMachine = vendingMachine;
            
            //Add purchase menu options
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);
            AddOption("Exit", Exit);

            //Configure look of menu
            Configure(cfg =>
            {
                cfg.Title = "*** Purchase Menu ***";
                cfg.ItemForegroundColor = ConsoleColor.Blue;
                cfg.SelectedItemForegroundColor = ConsoleColor.White;
                cfg.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
                cfg.Selector = ">> ";
                cfg.BeepOnError = true;
            });
        }

        //Make feed money menu option result
        private MenuOptionResult FeedMoney()
        {
            //Ask how much money the costomer wants to feed in
            Console.WriteLine("How much money would you like to feed the machine? $1 $2 $5 or $10 only");

            //Declare money med and extra money fed decimals
            decimal moneyFed = 0.00M;
            decimal extraMoneyFed = 0.00M;
            
            //Read the inputted bill ad assign it to money fed
            moneyFed = decimal.Parse(Console.ReadLine());


            //If input is a valid bill feed money into vending machine
            if (moneyFed == 1 || moneyFed == 2 || moneyFed == 5 || moneyFed == 10)
            {
                this.vendingMachine.FeedMoneyIn(moneyFed);
            }
            //Else notify customer of error
            else
            {
                moneyFed = 0.00M;
                Console.WriteLine("Error: Please enter only $1, $2, $5, or $10");
            }
            
            //Ask user if they want to feed in more money
            Console.WriteLine($"Current money provided = ${moneyFed} Would you like to add more? (Y/N)");
            string yesOrNo = Console.ReadLine();

            //Make a while loop that keeps asking and feeding money as long as the user wants to
            while (yesOrNo == "Y" || yesOrNo == "y")
            {
                Console.WriteLine("How much more would you like to add?");
                extraMoneyFed = decimal.Parse(Console.ReadLine());

                //Log money fed
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\log.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY: ${moneyFed} ${vendingMachine.Balance}");
                }

                //check if bill is valid again
                if (extraMoneyFed == 1 || extraMoneyFed == 2 || extraMoneyFed == 5 || extraMoneyFed == 10)
                {
                    moneyFed += extraMoneyFed;
                    vendingMachine.FeedMoneyIn(extraMoneyFed);
                    Console.WriteLine($"Current money provided is now = ${moneyFed} Would you like to add more? (Y/N)");
                    yesOrNo = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error: Please enter only $1, $2, $5, or $10");
                    
                }
            }
            //Return to main menu
            if (yesOrNo == "N" || yesOrNo == "n")
            {
                Console.WriteLine("Press enter to return to Purchase Menu");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        //TODO 02: Finish commenting code
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
                                if (prod.Category == "Chip")
                                {
                                    Console.WriteLine("Crunch Crunch, Yum!");
                                }
                                if (prod.Category == "Candy")
                                {
                                    Console.WriteLine("Munch Munch, Yum!");
                                }
                                if (prod.Category == "Drink")
                                {
                                    Console.WriteLine("Glug Glug, Yum!");
                                }
                                if (prod.Category == "Gum")
                                {
                                    Console.WriteLine("Chew Chew, Yum!");
                                }
                            }
                            if (prod.Quantity < 1)
                            {
                                Console.WriteLine("This product is sold out. Please enter a different slot location.");
                            }
                        }
                        else
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

        private MenuOptionResult FinishTransaction()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} GIVE CHANGE: ${vendingMachine.Balance} $0.00");
            }

            List<int> change = vendingMachine.dispenseChange();

            Console.WriteLine($"You have been dispensed {change[0]} quarters {change[1]} dimes and {change[2]} nickels!");


            return MenuOptionResult.WaitThenCloseAfterSelection;
        }
        
    }

}
