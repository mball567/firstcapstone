using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        //Set properties of vending machine. Inventory as a list of prducts, Balance as a decimal 
        public List<Product> Inventory { get; set; }

        public decimal Balance { get; set; } = 0;

        //Constructor for vending machine that is passed in a list of products
        public VendingMachine(List<Product> products)
        {
            //Assign that list of products to the vending machines Inventory
            Inventory = products;
        }

        //Methods
        //Make a method that feeds $1, $2, $5, or $10 into the machine
        public decimal FeedMoneyIn(decimal moneyFed)
        {
            //Only accept proper bills
            if (moneyFed == 1.00M || moneyFed == 2.00M || moneyFed == 5.00M || moneyFed == 10.00M)
            {
                Balance += moneyFed;
            }
            //TODO 01: Check if these lines are neccessary
            //else
            //{
            //    Balance += 0;
            //}

            //Write a log of this transaction to the log file
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} FEED MONEY: ${moneyFed} ${Balance}");
            }

            return Balance;
        }

        //Make a dispense item method that is passed in a slot loaction and dispenses a product at that slot location in the inventory
        public Product dispenseItem(string slotLocation)
        {
            //Loop through all the products in Inventory  
            foreach (Product prod in Inventory)
            {
                //Check if the slot location passed in is the same as the slot location for the product
                if (prod.SlotLocation == slotLocation)
                {
                    //Write to log
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\log.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now} {prod.Name} {prod.SlotLocation} ${Balance} ${Balance - prod.Price}");
                    }
                    //Decrement quantity and subtract the price of the pruct from the Balance
                    prod.Quantity--;
                    Balance -= prod.Price;
                    
                    //Return the product
                    return prod;
                }
            }

            return null;
        }

        //Make a dispense change method returning a list of integers, each representing the proper number of each coin dispensed
        public List<int> dispenseChange()
        {
            //Create coin variables
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            //Divide the balance by .25 then assign it to quarters. Modulo by .25 to decrement the balance
            quarters = (int)(Balance / .25M);
            Balance %= .25M;

            //If theres any change left after dividing the balance into quarters, try dimes
            if (Balance > 0)
            {
                dimes = (int)(Balance / .10M);
                Balance %= .10M;

                //Try nickels
                if (Balance > 0)
                {
                    nickels = (int)(Balance / .05M);
                    Balance %= .05M;
                }
            }

            //Make a new list that holds the change ints
            List<int> change = new List<int>();

            //Add the change to list
            change.Add(quarters);
            change.Add(dimes);
            change.Add(nickels);

            return change;
        }
    }
}
