using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private string _randomPrompt;

    //private string _randomPromptQuestion;
    private List<string> _listOfPrompts;
    private List<string> _listOfPromptQuestions;
    private List<int> _listOfIndex;

    public ReflectingActivity()
    {
        _activityName = "Reflecting";
        _description = "This activity will help you refelct on the times in your life when you have shown strength and resilience. This will help you recognise the power you have and how you can use it in other aspects of your life.";

        
        //Read from file and set the values for _listOfPrompts
        _listOfPrompts = ReadFromFile("prompts.txt");

        //Assign a value to the _randomPrompt attribute by random selection
        _randomPrompt = GetRandomPrompt();

        //Read from file and set the values for _listOfPromptQuestions
        _listOfPromptQuestions = ReadFromFile("promptQuestions.txt");

        List <int> listOfIndex = new List<int>();
        _listOfIndex = listOfIndex;


    }

    public void StartReflectingActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(5);
        Console.WriteLine();

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        while (pressedKey.Key != ConsoleKey.Enter) //do nothing unless Enter key is pressed
        {
            pressedKey = Console.ReadKey();
        }

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        PauseCountdownTimer(5, "You may begin in...");

        Console.Clear();

        DisplayPromptQuestionAndReflect();


    }
    
    private string GetRandomPrompt()
    {
        int randIndex = GetRandomIndex(_listOfPrompts);

        string randomPrompt = _listOfPrompts[randIndex];

        return randomPrompt;
    }

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

    public void DisplayPrompt()
    {
        
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {_randomPrompt} ---\n");

    }

    public void DisplayPromptQuestionAndReflect()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            
            string promptQuestion = "> " + GetRandomPromptQuestion() + " ";
            Console.WriteLine(promptQuestion);
            Console.SetCursorPosition(promptQuestion.Length, Console.CursorTop - 1);
            PauseSpinner(10);
            Console.WriteLine();
            
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


}