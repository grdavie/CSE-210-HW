using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Journal Program!");
        
        int userChoice = -1;

        while (userChoice!=5) //quits program if userChoice is 5

        {
        
            Console.WriteLine("\nPlease select one of the following choices: ");
            Console.WriteLine("1.Write\n2.Display\n3.Load\n4.Save\n5.Quit");
            Console.Write("\nWhat would you like to do? ");
            userChoice = int.Parse(Console.ReadLine());

            //Console.WriteLine(userChoice);
        
            if (userChoice == 1)
            {
                PromptGenerator journalPrompt = new PromptGenerator();
                List<string> listOfPrompts = new List<string>();

                listOfPrompts = journalPrompt._prompt;
                string randomJournalPrompt = journalPrompt.ReturnRandomPrompt(listOfPrompts); 

                Console.WriteLine($"\n{randomJournalPrompt}");
                Console.Write("> ");
                string userInput = Console.ReadLine();

                Entry journal1 = new Entry();
                journal1._randomPrompt = randomJournalPrompt;
                journal1._journalEntry = userInput;
                journal1.DisplayEntry();


            }
        
        }

     
        

    }
}