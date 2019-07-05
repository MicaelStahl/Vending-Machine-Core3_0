using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Core3.Products
{
    class Food : IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Description { get; set; }

        public void Bought(string name)
        {
            Display display = new Display();
            display.SuccessMessage($"You bought {name}! Do you want to eat the product? y/n");
        }

        public void UseProduct(string name)
        {
            Display display = new Display();
            display.SuccessMessage($"You start eating the {name}!");
        }
    }
}
