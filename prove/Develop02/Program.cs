using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        
        Journal journal = new Journal(); //creating an instance of 
        List<Entry> listofEntries = new List<Entry>();
        listofEntries = journal._entries;
        
        Console.WriteLine("\nWelcome to the Journal Program!");
        
        int userChoice = -1;

        while (userChoice!=5) //quits program if userChoice is 5

        {
        
            Console.WriteLine("\nPlease select one of the following choices: ");
            Console.WriteLine("1.Write\n2.Display\n3.Load\n4.Save\n5.Quit");
            Console.Write("\nWhat would you like to do? ");
            userChoice = int.Parse(Console.ReadLine());

            //Console.WriteLine(userChoice);
        
            if (userChoice == 1) //Write
            {
                PromptGenerator promptgenerator = new PromptGenerator(); //PromptGenerator object created
                List<string> listOfPrompts = new List<string>(); //create a new list to hold the list of prompts inside the main program

                listOfPrompts = promptgenerator._prompt;
                string randomJournalPrompt = promptgenerator.ReturnRandomPrompt(listOfPrompts); 

                Console.WriteLine($"\n{randomJournalPrompt}");
                Console.Write("> ");
                string userInput = Console.ReadLine();

                Entry entry = new Entry();
                entry._randomPrompt = randomJournalPrompt;
                entry._journalEntry = userInput;
                
                //Add entry object to the journal object's list of Entry objects (i.e listOfEntries)   
                journal._newEntry = entry;
                journal.AddEntry(listofEntries, journal._newEntry);
                

                
            }

            else if (userChoice == 2) //Display
            {
                journal.DisplayEntries(listofEntries);
            }

            else if (userChoice == 3) //Load
            {
                journal.LoadFile();
            }

            else if (userChoice == 4) //Save
            {
                journal.SaveFile(listofEntries);
            }

            else if (userChoice < 1 || userChoice > 5) //invalid input
            {
                Console.WriteLine("You have entered an invalid option.");
                Console.WriteLine("Please choose between 1-5 only. Thank you!");
            }

            
            
        
        }

     
        

    }
}