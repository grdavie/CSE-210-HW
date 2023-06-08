using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int userChoice = -1; //set default userChoice value
        

        while (userChoice != 4)
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

            if (userChoice == 2)
            {
                ReflectingActivity reflect = new ReflectingActivity();
                reflect.DisplayStartMessage();
                reflect.StartReflectingActivity();
                reflect.DisplayEndMessage();
            }
        }

        Console.WriteLine("\nGood Bye!");

       


        //Program Methods:

        static void DisplayMenu()
        {
            Console.Clear();

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