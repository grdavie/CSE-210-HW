using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        
        Journal journal = new Journal(); //creating an instance of 
        List<Entry> listOfEntries = new List<Entry>();
        listOfEntries = journal._entries; //current list of Entry objects

        
        //For Loading Files:
        List<Entry> listOfPreviousEntries = new List<Entry>(); //created a new list to hold all the saved Entry objects loaded from file
        
        
        //Welcome Message
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("--------------------------------------------");
        
        int userChoice = -1;

        while (userChoice!=6) //quits program if userChoice is 5

        {
        
            Console.WriteLine("\nPlease select one of the following choices: ");
            Console.WriteLine("1.Write\n2.Display\n3.Edit\n4.Load\n5.Save\n6.Quit");
            Console.Write("\nWhat would you like to do? ");
            userChoice = int.Parse(Console.ReadLine());

            //Console.WriteLine(userChoice);
        
            if (userChoice == 1) //Write
            {
                PromptGenerator promptgenerator = new PromptGenerator(); //PromptGenerator object created
                List<string> listOfPrompts = new List<string>(); //create a new list to hold the list of prompts inside the main program

                listOfPrompts = promptgenerator._prompt;
                string randomJournalPrompt = promptgenerator.ReturnRandomPrompt(listOfPrompts); 

                //Display Random Prompt
                Console.WriteLine($"\n{randomJournalPrompt}");
                Console.Write("> ");
                string userInput = Console.ReadLine();

                //store random prompt and user input into the Entry object
                Entry entry = new Entry();
                entry._randomPrompt = randomJournalPrompt;
                entry._journalEntry = userInput;
                
                //Add entry object to the journal object's list of Entry objects (i.e listOfEntries)   
                journal._newEntry = entry;
                journal.AddEntry(listOfEntries, journal._newEntry);
                

                
            }

            else if (userChoice == 2) //Display
            {
                journal.DisplayEntries(listOfEntries); //displays current list of entries
            }

            else if (userChoice == 3) //Edit Entry
            {
                journal.EditEntry(listOfEntries);
            }

            else if (userChoice == 4) //Load
            {
                
                listOfPreviousEntries = journal.LoadFile();
                listOfEntries = listOfPreviousEntries; //replace the current list of entries with the previous list of entries
                
            }

            else if (userChoice == 5) //Save
            {
                journal.SaveFile(listOfEntries); //saves the current list of entries
            }

            else if (userChoice < 1 || userChoice > 6) //invalid input
            {
                Console.WriteLine("You have entered an invalid option.");
                Console.WriteLine("Please choose between 1-5 only. Thank you!");
            }

            
            
        
        }

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Thank you and Good Bye!");
        Console.WriteLine("--------------------------------------------\n");
     
        

    }
}