using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public Entry _newEntry;
    

    public void AddEntry(List<Entry> _entries, Entry _newEntry)
    {
        _entries.Add(_newEntry);
    }

    public void DisplayEntries(List<Entry> _entries)
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveFile(List<Entry> _entries)
    {
        Console.WriteLine("Saving file...");
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date: {entry._dateText} - Prompt: {entry._randomPrompt}");
                outputFile.WriteLine(entry._journalEntry);
            }
        }

    }

    public List<Entry> LoadFile()
    {
        List<Entry> previousEntries = new List<Entry>();
        
        Console.WriteLine("Loading file...");
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        string [] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
    
        }

        return previousEntries;
    }

    //it's not getting pushed to github????

}