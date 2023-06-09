using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private string _randomPrompt;
    private List<string> _listOfPrompts;
    private List<string> _listOfPromptQuestions;
    private List<int> _listOfIndex;

    public ReflectingActivity(List<string> listOfPreviousRandomPrompts)
    {
        
        //constructor sets the value for the Activity class protected attributes
        _activityName = "Reflecting";
        _description = "This activity will help you refelct on the times in your life when you have shown strength and resilience. This will help you recognise the power you have and how you can use it in other aspects of your life.";

        
        //Read from file and set the values for _listOfPrompts
        _listOfPrompts = ReadFromFile("prompts.txt");

        //Assign a value to the _randomPrompt attribute by random selection
        
        _randomPrompt = GetRandomPrompt();

        //keep generating a random prompt if it's already in main program's previous random prompt list
        while (listOfPreviousRandomPrompts.Contains(_randomPrompt))
        {
            _randomPrompt = GetRandomPrompt();
        }

        //add the random prompt to main program list so it doesn't show up again
        listOfPreviousRandomPrompts.Add(_randomPrompt);

        //Read from file and set the values for _listOfPromptQuestions
        _listOfPromptQuestions = ReadFromFile("promptQuestions.txt");

        //create an empty list to hold index numbers to get unique prompt questions when it runs
        List <int> listOfIndex = new List<int>();
        _listOfIndex = listOfIndex;


    }

    public void StartReflectingActivity() //method to initiate the whole reflecting activity
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(5); //5 second spinner
        Console.WriteLine();

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        ConsoleKeyInfo pressedKey = Console.ReadKey(true); //read the pressed keys

        while (pressedKey.Key != ConsoleKey.Enter) //do nothing unless Enter key is pressed
        {
            pressedKey = Console.ReadKey();
        }

        //if enter key is pressed, message below will appear:
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        PauseCountdownTimer(5, "You may begin in..."); //5 second timer

        Console.Clear();

        DisplayPromptQuestionAndReflect();


    }
    
    //helper method to get a random prompt
    private string GetRandomPrompt()
    {
        int randIndex = GetRandomIndex(_listOfPrompts);

        string randomPrompt = _listOfPrompts[randIndex];

        return randomPrompt;
    }

    //helper method to get a unique random prompt question each time
    private string GetRandomPromptQuestion()
    {
        int randIndex = GetRandomIndex(_listOfPromptQuestions);

        while (_listOfIndex.Contains(randIndex))
        {
            randIndex = GetRandomIndex(_listOfPromptQuestions);
        }

        _listOfIndex.Add(randIndex);

        return _listOfPromptQuestions[randIndex];

    }

    private void DisplayPrompt()
    {
        
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {_randomPrompt} ---\n");

    }

    private void DisplayPromptQuestionAndReflect() 
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime) //keep getting unique random prompt question until duration ends
        {
            
            string promptQuestion = "> " + GetRandomPromptQuestion() + " ";
            Console.WriteLine(promptQuestion);
            
            //set cursor position so that next item on the console will appear next to the prompt question
            Console.SetCursorPosition(promptQuestion.Length, Console.CursorTop - 1);
            PauseSpinner(10); //10 second spinner that will show up next to the promptQuestion on the same line
            Console.WriteLine(); //so that next item on the loop will appear on a new line
            
        }
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

    public int GetListOfPromptsCount()
    {
        return _listOfPrompts.Count;
    }


}