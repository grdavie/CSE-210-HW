using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    public List<Entry> _entries = new List<Entry>(); //a new list of Entry objects
    public Entry _newEntry; //Entry object created should be assigned as the value for this attribute
    

    public void AddEntry(List<Entry> _entries, Entry _newEntry) //takes the list of Entry objects and an Entry object as parameters 
    {
        _entries.Add(_newEntry); //entry object gets added to the list of Entry objects
    }

    public void DisplayEntries(List<Entry> _entries) //takes the list of Entry objects as its parameter
    {
        foreach (Entry entry in _entries) //iterate through the list of Entry objects to display all entries added to it
        {
            int index = _entries.IndexOf(entry); //returns the 0 based index number of each Entry object in the list
            int logNumber = index + 1; //starts the entry count from 1 instead of 0

            Console.WriteLine($"Journal Entry #{logNumber}");
            entry.DisplayEntry();
        }
    }

    public void EditEntry (List<Entry> _entries)
    {
        Console.Write("Which entry do you want to edit? ");
        int logNumber = int.Parse(Console.ReadLine());
        int index = logNumber - 1; //turn the entry object's logNumber to its 0 based index 

        Console.WriteLine("\nPlease select one of the following choices: \n1. Update journal entry \n2. Delete journal entry");
        Console.Write("\nWhat would you like to do? ");
        int userEditChoice = int.Parse(Console.ReadLine()); 

        if (userEditChoice == 1)
        {
            Console.WriteLine($"{_entries[index]._randomPrompt}");
            Console.Write("> ");
            string newInput = Console.ReadLine();
            
            _entries[index]._journalEntry = newInput;

            Console.WriteLine("\nYour Journal Entry has been updated!");
        }

        else if (userEditChoice == 2)
        {
            _entries.RemoveAt(index); //removes the Entry object from the list

            Console.WriteLine("Your Journal Entry has been deleted!");
        }

        else
        {
            Console.WriteLine("You have entered an invalid option.");
            Console.WriteLine("Editing has been cancelled. Please try again.");
        }
    }

    public void SaveFile(List<Entry> _entries) //takes the list of Entry objects as its parameter
    {
        
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine(); //user input filename.type
        
        if (File.Exists(filename)) //confirm if user wants to overwrite existing file

        {
            Console.WriteLine("\nFile already exists!");
            Console.Write($"Are you sure you want to overwrite {filename}? Enter (y) to continue, any key to cancel : ");
            string userInput = Console.ReadLine().ToLower(); //will work whether upper case Y or lowercase y is used
        
            if (userInput == "y")

            {
                Console.WriteLine($"Your file {filename} was saved successfully!");

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries) //iterate through the list of Entry objects and store each attribute on the file created
                    {
                        outputFile.WriteLine($"{entry._dateText}~~{entry._randomPrompt}~~{entry._journalEntry}"); //format that makes it easy to split later on

                    }
                }
            }

            else 

            {
                Console.WriteLine("File not saved.");
            }


        }

        else //if file doesn't exist, save new file automatically
        {
            Console.WriteLine($"Your file {filename} was saved successfully!");

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries) //iterate through the list of Entry objects and store each attribute on the file created
                    {
                        outputFile.WriteLine($"{entry._dateText}~~{entry._randomPrompt}~~{entry._journalEntry}"); //format that makes it easy to split later on

                    }
                }
        }

    }

    public List<Entry> LoadFile() //creates and returns a new list of Entry objects that stores all of the lines inside of the file created from SaveFile method
    {
        List<Entry> savedEntries = new List<Entry>();
         
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine(); //user input filename.type
       

        if (File.Exists(filename)) //Load successfully if file exists
        {
        
            Console.WriteLine();
            Console.WriteLine($"Your file {filename} was loaded successfully!");

            string [] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                //each line on the file will look like this {date}~~{random prompt}~~{user journal input}

                string[] parts = line.Split("~~");
            
                //parts[0] - date
                //parts[1] - random prompt
                //parts[2] - user journal input

                Entry newEntry = new Entry();
                newEntry._dateText = parts[0];
                newEntry._randomPrompt = parts[1];
                newEntry._journalEntry = parts[2];

                savedEntries.Add(newEntry);
    
            }

            return savedEntries; //returns list of previously saved entries as new Entry objects

        }

        else //handle file doesn't exist error so program doesn't crash
        {
            Console.WriteLine("\nERROR!");
            Console.WriteLine("File doesn't exist. Please create it or load a different file");

            return savedEntries; //returns nothing
        }
    }

    

}