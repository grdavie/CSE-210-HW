using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string _listPrompt;
    private List<string> _listAnswers;
    private List<string> _listOfListPrompts;

    public ListingActivity(List<string> listOfPreviousListPrompts)
    {
        //constructor sets the value for the Activity class protected attributes
        _activityName = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        //Read from file and set the values for _listOfListPrompts
        _listOfListPrompts = ReadFromFile("listPrompts.txt");

        //Assignn a value to the _listPrompt attribute by random selection from _listOfListPrompts
        _listPrompt = GetListPrompt();

        //keep generating a list prompt if it's already in main program's previous list prompt list
        while (listOfPreviousListPrompts.Contains(_listPrompt))
        {
            _listPrompt = GetListPrompt();
        }

        //add the random prompt to main program list so it doesn't show up again
        listOfPreviousListPrompts.Add(_listPrompt);

        //create an empty list to store list answers
        List<string> listAnswers = new List<string>();
        _listAnswers = listAnswers;
    }

    public void StartListingActivity() //initiate the specific listing activity behaviour
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(5); //5 second spinner
        Console.WriteLine();

        DisplayPrompt();

        Console.WriteLine();
        PauseCountdownTimer(5, "You may begin in..."); //5 second timer
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime) //keep prompting user input if duration hasn't ended yet
        {
            Console.Write("> ");
            string userInput = Console.ReadLine();
            _listAnswers.Add(userInput); //add the string input to the list so we can count them
        }

        //display the number of items listed
        Console.WriteLine($"\nYou listed {GetListCount()} items!");
    }

    //helper method to get a random list prompt
    private string GetListPrompt()
    {
        int randIndex = GetRandomIndex(_listOfListPrompts);
        
        string listPrompt = _listOfListPrompts[randIndex];

        return listPrompt;

    }

    private void DisplayPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($" --- {_listPrompt} ---\n");

    }

    //get the object count inside the list
    private int GetListCount()
    {
        return _listAnswers.Count;
    }


    //ReadFromFile helper method
    private static List<string> ReadFromFile(string txtFilename) 
    {
        List<string> newList = new List<string>();
        string filename = txtFilename; //text file that stores all the prompts 

        string[] lines = System.IO.File.ReadAllLines(filename); //file is read as an array of strings (one per line)

        foreach (string line in lines)
        {
            newList.Add(line); //each line is added to the list of prompts
        }

        return newList;

    }

        //Random index helper method
    private static int GetRandomIndex(List<string> list)
    {

        Random randNum = new Random();
        
        return randNum.Next(0, list.Count);
        
    }

    public int GetListofListPromptsCount()
    {
        return _listOfListPrompts.Count;
    }
    
}