using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int userChoice = -1; //set default userChoice value
        
        Console.Clear();


        while (userChoice != 4) //breaks the loop or quits the program if user input is 4
        {
            try
            {
                DisplayMenu();
                userChoice = GetUserChoice();

           
                if (userChoice == 1)
                {
                    BreathingActivity breathe = new BreathingActivity();
                    breathe.DisplayStartMessage();
                    breathe.StartBreathingActivity();
                    breathe.DisplayEndMessage();
                }

                else if (userChoice == 2)
                {
                    ReflectingActivity reflect = new ReflectingActivity();
                    reflect.DisplayStartMessage();
                    reflect.StartReflectingActivity();
                    reflect.DisplayEndMessage();
                }

                else if (userChoice == 3)
                {
                    ListingActivity list = new ListingActivity();
                    list.DisplayStartMessage();
                }

                else 
                {
                    Console.WriteLine("Please choose between 1-4 only. Thank you!");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Thread.Sleep(1000);
                Console.Clear();

            }

        }

        Console.WriteLine("\nGood Bye!");

       


        //Program Methods:

        static void DisplayMenu()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Welcome to the Mindfulness Program");
            Console.WriteLine("--------------------------------------------\n");

            Console.WriteLine("Select an Activity from the Menu:\n");
            Console.WriteLine("   1. Start breathing activity");
            Console.WriteLine("   2. Start reflecting activity");
            Console.WriteLine("   3. Start listing activity");
            Console.WriteLine("   4. Quit");

        }

        static int GetUserChoice()
        {
            Console.Write("\nWhat would you like to do? ");
            int userInput = int.Parse(Console.ReadLine());

            return userInput;

        }
    }

   
}