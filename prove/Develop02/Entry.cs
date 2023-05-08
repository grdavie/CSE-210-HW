using System;

public class Entry
{
    public string _dateText = ReturnDateText();
    public PromptGenerator _randomPrompt;
    public string _journalEntry;

    public static string ReturnDateText()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        return dateText;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_dateText} - Prompt: {_randomPrompt}");
        Console.WriteLine(_journalEntry);
    }

}