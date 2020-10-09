using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string SlotLocation { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; } = 5;

        public Product(string slotLocation, string name, decimal price, string category)
        {
            Category = category;
            Price = price;
            Name = name;
            SlotLocation = slotLocation;
        }
    }
}
