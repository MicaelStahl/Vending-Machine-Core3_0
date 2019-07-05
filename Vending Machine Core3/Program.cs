using System;

namespace Vending_Machine_Core3
{
    class Program
    {
        static void Main(string[] args)
        {
            var stayAlive = true;
            int money = 0;

            Display display = new Display();
            Change change = new Change();
            VendingMachine machine = new VendingMachine();

            display.DisplayMessage("Hello and welcome to my Vending Machine in Code 3.0!");
            display.DisplayMessage("Remember to hit the like button and subscribe!");
            Console.ReadKey(false);

            do
            {
                try
                {
                    Console.Clear();
                    display.DisplayMessage(
                        "--- Menu --- \n" +
                        "1: View The available categories\n" +
                        "2: Check your current amount of change\n" +
                        "3: Add change to the machine\n" +
                        "0: Exit application\n"
                        );
                    var choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            money = machine.VendingMachineBody(money);
                            break;
                        case 2:
                            display.SuccessMessage($"Your current change is {money}!\n Press any key to continue . . .");
                            Console.ReadKey(false);
                            break;
                        case 3:
                            var newMoney = change.AddChange(money);
                            money += newMoney;
                            break;
                        case 0:
                            display.SuccessMessage("Thanks for using my application. Have a nice day!\n " +
                                $"Here's the remaining change back: {money}");
                            Console.ReadKey(false);
                            stayAlive = false;
                            break;
                        default:
                            throw new ArgumentException($"{choice} is not a valid option! Please try again");
                    }
                }
                catch (FormatException ex)
                {
                    display.ErrorMessage(ex.Message ?? "Something went wrong.");
                }
                catch (ArgumentException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
            } while (stayAlive);
        }
    }
}
