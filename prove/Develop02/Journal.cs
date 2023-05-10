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
        Console.WriteLine($"Saving {filename} file...");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries) //iterate through the list of Entry objects and call its attributes to store on the file created
            {
                outputFile.WriteLine($"Date: {entry._dateText} - Prompt: {entry._randomPrompt}");
                outputFile.WriteLine();
                outputFile.WriteLine($"> {entry._journalEntry}\n");
                
            }
        }

    }

    public List<Entry> LoadFile() //creates and returns a new list of Entry objects that stores all of the lines inside of the file created from SaveFile method
    {
        List<Entry> previousEntries = new List<Entry>();
        
        
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine(); //user input filename.type
        Console.WriteLine($"Loading {filename} file...");

        string [] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Console.WriteLine(line); //display all the lines stored inside the file
    
        }

        return previousEntries;
    }

    

}