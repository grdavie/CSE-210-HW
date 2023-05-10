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
            entry.DisplayEntry();
        }
    }

    public void SaveFile(List<Entry> _entries) //takes the list of Entry objects as its parameter
    {
        
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine(); //user input filename.type
        Console.WriteLine($"Your file {filename} was saved successfully!");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries) //iterate through the list of Entry objects and store each attribute on the file created
            {
                outputFile.WriteLine($"{entry._dateText}~~{entry._randomPrompt}~~{entry._journalEntry}"); //format that makes it easy to split later on
                
            }
        }

    }

    public  List<Entry> LoadFile() //creates and returns a new list of Entry objects that stores all of the lines inside of the file created from SaveFile method
    {
        List<Entry> savedEntries = new List<Entry>();
         
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine(); //user input filename.type
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

        return savedEntries;
    }

    

}