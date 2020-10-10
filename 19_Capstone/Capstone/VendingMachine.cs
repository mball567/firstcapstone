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
        public List<Product> Inventory { get; set; }

        public decimal Balance { get; set; } = 0;

        public VendingMachine(List<Product> products)
        {
            Inventory = products;
        }

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
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} FEED MONEY: ${moneyFed} ${Balance}");
            }

        }
        public Product dispenseItem(string slotLocation)
        {

            foreach (Product prod in Inventory)
            {
                if (prod.SlotLocation == slotLocation)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-module-1-capstone-team-0\19_Capstone\log.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now} {prod.Name} {prod.SlotLocation} ${Balance} ${Balance - prod.Price}");
                    }

                    prod.Quantity--;
                    Balance -= prod.Price;

                    return prod;
                }
            }

            return null;
        }

        //dispenseChange with modulus
        public List<int> dispenseChange()
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

                if (Balance > 0)
                {
                    nickels = (int)(Balance / .05M);
                    Balance %= .05M;
                }
            }

            List<int> change = new List<int>();

            change.Add(quarters);
            change.Add(dimes);
            change.Add(nickels);

            return change;
        }
    }
}
