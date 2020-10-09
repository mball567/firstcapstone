using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone
{
    public class VendingMachine 
    {
        public List<Product> Inventory { get; set; }

        public decimal Balance { get; set; } = 0;

        //feedMoney -add money to balance

        public void FeedMoneyIn(decimal moneyFed)
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
        public void GetProductList()
        {
            string filePath = @"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\vendingmachine.csv";
            ProductLoader newLoader = new ProductLoader();
            List<Product> productList = new List<Product>();

            productList = newLoader.LoadProducts(filePath);

            Inventory = productList;
        }

        //dispenseItem() ask for product code, if doesn't exist, send back to purchase menu, as as sold out
            //if valid dispense/return item
            //update balance
        public Product dispenseItem(string slotLocation)
        {
            
            foreach (Product prod in Inventory)
            {
                if (prod.SlotLocation == slotLocation)
                {
                    prod.Quantity--;
                    Balance -= prod.Price;
                    return prod;
                }              
            }
            return null;
        }

        //dispenseChange with modulus
        public decimal dispenseChange()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            
            quarters = (int)(Balance / .25M);
            Balance %= .25M;

            if (Balance > 0)
            {
                dimes = (int)(Balance / .10M);
                Balance %= .10M;

                if(Balance > 0) 
                {
                    nickels = (int)(Balance / .05M);
                    Balance %= .05M;
                }                   
            }          
            return Balance;
        }                
    }
}
