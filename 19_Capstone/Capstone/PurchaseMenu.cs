using MenuFramework;
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

            this.vendingMachine.FeedMoneyIn(moneyFed);
            
            
            Console.WriteLine($"Current money provided = ${moneyFed} Would you like to add more? (Y/N)");
            string yesOrNo = Console.ReadLine();

            
            while (yesOrNo == "Y" || yesOrNo == "y")
            {
                Console.WriteLine("How much more would you like to add?");
                extraMoneyFed = decimal.Parse(Console.ReadLine());
                moneyFed += extraMoneyFed;
                Console.WriteLine($"Current money provided is now = ${moneyFed} Would you like to add more? (Y/N)");
                yesOrNo = Console.ReadLine();
            }
            if (yesOrNo == "N" || yesOrNo == "n")
            {
                Console.WriteLine("Press enter to return to Purchase Menu");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
