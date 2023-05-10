using System;

public class Entry
{
    public string _dateText = ReturnDateText(); //the dateText string generated when the Entry class is instantiated gets assigned as the value for this attribute
    public string _randomPrompt; //the string returned by the ReturnRandomPrompt(List<string> _prompt) method of the PromptGenerator class should be assigned as the value for this attribute
    public string _journalEntry; //the user response or input for the journal prompt should be assigned as the value for this attribute

    public static string ReturnDateText() //returns the current date in mm/dd/yyyy format as a string
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        return dateText;
    }

    public void DisplayEntry() //displays the date text, the random prompt generared, and the user input
    {
        Console.WriteLine($"Date: {_dateText} - Prompt: {_randomPrompt}");
        Console.WriteLine();
        Console.WriteLine($"> {_journalEntry}\n");
    }

}