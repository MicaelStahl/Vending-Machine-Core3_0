using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine_Core3.Products;

namespace Vending_Machine_Core3
{
    class VendingMachine
    {
        public int VendingMachineBody(int money)
        {
            var stayAlive = true;
            List<IProducts> products = new List<IProducts>();

            #region Lists of products

            var foods = new List<Food>()
            {
                new Food() { Id=1, Name="Hawaii", Cost=75, Description="A standard cheese pizza with Pineapple on." },
                new Food() { Id=2, Name="Big Mac", Cost=55, Description="The most popular hamburger from McDonald's." },
                new Food() { Id=3, Name="Nasigoreng", Cost=21, Description="A rice mix with various spices and vegetables" },
                new Food() { Id=4, Name="Cheeseburger", Cost=10, Description="A standard Cheeseburger from McDonald's" }
            };
            var drinks = new List<Drinks>()
            {
                new Drinks() { Id=1, Name="Coca Cola", Cost=12, Description="A regular 33cl can of Coca Cola" },
                new Drinks() { Id=2, Name="Fanta", Cost=12, Description="A regular 33cl can of Fanta" },
                new Drinks() { Id=3, Name="Carbonated water", Cost=5, Description="Regular carbonated water" }
            };
            var snacks = new List<Snacks>()
            {
                new Snacks() { Id=1, Name="Tutti Frutti", Cost=23, Description="A bag of various Tutti Frutti candy" },
                new Snacks() { Id=2, Name="Dumle", Cost=19, Description="A bag of Dumle" },
                new Snacks() { Id=3, Name="Twix", Cost=6, Description="A Singular Twix" }
            };
            #endregion

            Display display = new Display();
            ShowProducts show = new ShowProducts();

            Console.Clear();
            do
            {
                try
                {
                    display.SuccessMessage($"Your currency is {money}");
                    display.DisplayMessage(
                        "There are currently 3 categories available. Pick one to view the wares.\n" +
                        "1: Food\n" +
                        "2: Drinks\n" +
                        "3: Snacks\n" +
                        "0: Return to menu\n"
                        );
                    var choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            products.AddRange(foods);
                            money = show.Show(products, money);
                            break;
                        case 2:
                            products.AddRange(drinks);
                            money = show.Show(products, money);
                            break;
                        case 3:
                            products.AddRange(snacks);
                            money = show.Show(products, money);
                            break;
                        case 0:
                            stayAlive = false;
                            break;
                        default:
                            throw new ArgumentException("Please insert a valid option.");
                    }

                }
                catch (ArgumentException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
                catch (Exception)
                {
                    display.ErrorMessage("Something went wrong.");
                }
            } while (stayAlive);
            return money;
        }
    }
}
