using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Core3.Products
{
    public interface IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? Cost { get; set; }

        public string Description { get; set; }

        public void Bought(string name);

        public void UseProduct(string name);
    }
}
