using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine_Core3.Products;

namespace Vending_Machine_Core3
{
    class BuyProduct
    {
        public int Buy(IProducts product, int? totalMoney)
        {
            var stayAlive = true;
            Display display = new Display();

            do
            {
                try
                {

                    // Picking 5 because in this assignment the lowest costing product I have costs 5.
                    if (totalMoney < 5)
                    {
                        throw new FormatException($"You do not have enough money to buy {product.Name}.");
                    }
                    else
                    {
                        totalMoney -= product.Cost;
                        product.Bought(product.Name);
                        var choice = Convert.ToChar(Console.ReadKey(true));

                        if (choice == 'y')
                        {
                            product.UseProduct(product.Name);
                            stayAlive = false;
                        }
                        else if (choice == 'n')
                        {
                            stayAlive = false;
                        }
                        else
                        {
                            throw new ArgumentException("You did not pick a valid input. Please try again.");
                        }

                    }
                }
                catch (ArgumentNullException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
                catch (FormatException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
                catch (Exception)
                {
                    display.ErrorMessage("Something went wrong.");
                }
            } while (stayAlive);

            return (int)totalMoney;
        }
    }
}
