using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine 
    {
        private List<Product> inventoryList;

        public decimal Balance { get; set; } = 0;
        public IEnumerable<Product> LoadProducts { get; private set; }

        //feedMoney -add money to balance

        public void FeedMoney(decimal moneyFed)
        {
            if (moneyFed == 1.00M || moneyFed == 2.00M || moneyFed == 5.00M || moneyFed == 10.00M)
            {
                Balance += moneyFed;
            } 
            else
            {
                Balance += 0;
            }

        }

        // reference to an object of type. //return product list we made in product loader
        //printProductList() loop through slot products and return properties ( these will be printed in Menu)
        public Dictionary<string, string> PrintProductList()
        {
            
        }

        //dispenseItem() ask for product code, if doesn't exist, send back to purchase menu, as as sold out
            //if valid dispense/return item
            //update balance
            //in menu print item name, cost, and money remaining, and message

        //finishTransaction() %
         //return proper change 
         //return to main menu (and print on menu)


    }
}
