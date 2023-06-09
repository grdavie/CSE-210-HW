using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Create empty lists to store all the prompts that show up during the session
        List<string> listOfPreviousRandomPrompts = new List<string>();
        List<string> listOfPreviousListPrompts = new List<string>();

        int previousPromptsCount = 0;
        int previousListPromptsCount = 0;

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
                    ReflectingActivity reflect = new ReflectingActivity(listOfPreviousRandomPrompts);
                    reflect.DisplayStartMessage();
                    reflect.StartReflectingActivity();
                    reflect.DisplayEndMessage();

                    //update the previouspromptscount with the current list count
                    previousPromptsCount = listOfPreviousRandomPrompts.Count;

                    //get the actual count of prompts inside the list
                    int listOfPromptsCount = reflect.GetListOfPromptsCount();


                    //compare the values so that if all prompts have been used, reset the session by emptying
                    //the previous prompts list. 
                    if (previousPromptsCount == listOfPromptsCount)
                    {
                        listOfPreviousRandomPrompts.Clear();
                    }

                }

                else if (userChoice == 3)
                {
                    ListingActivity list = new ListingActivity(listOfPreviousListPrompts);
                    list.DisplayStartMessage();
                    list.StartListingActivity();
                    list.DisplayEndMessage();

                    //update the previoulistpromptscount with the current list count
                    previousListPromptsCount = listOfPreviousListPrompts.Count;

                    //get the actual count of list prompts inside the list
                    int listOfListPromptsCount = list.GetListofListPromptsCount();

                    //compare the values so that if all prompts have been used, reset the session by emptying
                    //the previous list prompts list. 
                    if (previousListPromptsCount == listOfListPromptsCount)
                    {
                        listOfPreviousListPrompts.Clear();
                    }

                }

                else if (userChoice == 4)
                {
                    break;
                }
                
                //limit user input to numbers within the menu option
                else 
                {
                    Console.WriteLine("Please choose between 1-4 only. Thank you!");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }

            //exception handling if user inputs non-integer
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