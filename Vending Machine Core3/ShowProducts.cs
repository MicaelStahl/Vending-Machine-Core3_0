using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vending_Machine_Core3.Products;

namespace Vending_Machine_Core3
{
    class ShowProducts
    {
        public int Show(List<IProducts> products, int money)
        {
            var stayAlive = true;
            Display display = new Display();
            BuyProduct buy = new BuyProduct();

            do
            {
                try
                {
                    display.DisplayMessage("Please pick one of the following products:");

                    foreach (var item in products)
                    {
                        display.DisplayMessage($"{item.Id}: Name: {item.Name} - Cost: {item.Cost} - Description: {item.Description}\n");
                    }
                    var choice = int.Parse(Console.ReadLine());

                    if (choice > products.Count || choice < 0)
                    {
                        throw new ArgumentException("Your choice was not valid. Please try again");
                    }
                    else
                    {
                        var product = products.SingleOrDefault(x => x.Id == choice);

                        if (product == null)
                        {
                            throw new ArgumentException("Your choice could not be found. Please try again");
                        }
                        else
                        {
                            money = buy.Buy(product, money);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
                catch (Exception)
                {
                    display.ErrorMessage("Something went wrong");
                }
            } while (stayAlive);

            return money;
        }
    }
}
