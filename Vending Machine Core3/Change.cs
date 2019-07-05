using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Core3
{
    class Change
    {
        public int AddChange(int? change)
        {
            var stayAlive = true;
            Display display = new Display();
            do
            {
                try
                {
                    Console.Clear();
                    if (change != null)
                    {
                        display.SuccessMessage($"Your change is currently  {change}");
                        display.DisplayMessage("Please pick a value of either 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000! \n" +
                            "Or 0 to return");
                        var newChange = int.Parse(Console.ReadLine());

                        switch (newChange)
                        {
                            case 1:
                                change += newChange;
                                break;
                            case 2:
                                change += newChange;
                                break;
                            case 5:
                                change += newChange;
                                break;
                            case 10:
                                change += newChange;
                                break;
                            case 20:
                                change += newChange;
                                break;
                            case 50:
                                change += newChange;
                                break;
                            case 100:
                                change += newChange;
                                break;
                            case 200:
                                change += newChange;
                                break;
                            case 500:
                                change += newChange;
                                break;
                            case 1000:
                                change += newChange;
                                break;
                            case 0:
                                stayAlive = false;
                                break;

                            default:
                                throw new ArgumentException("Please pick one of the valid values.");
                        }
                    }
                    else
                    {
                        throw new FormatException("Something went wrong. Please try again");
                    }
                }
                catch (FormatException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    display.ErrorMessage(ex.Message);
                }
                catch (Exception)
                {
                    display.ErrorMessage("Something went wrong. Please try again");
                }
            } while (stayAlive);
            return (int)change;
        }
    }
}
