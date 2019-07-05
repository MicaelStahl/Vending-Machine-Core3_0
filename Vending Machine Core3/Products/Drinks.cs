using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Core3.Products
{
    class Drinks : IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Description { get; set; }

        public void Bought(string name)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"You bought {name}! Do you want to drink the product? y/n");
            Console.ResetColor();
        }

        public void UseProduct(string name)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"You start drinking the {name}!");
            Console.ResetColor();
        }
    }
}
