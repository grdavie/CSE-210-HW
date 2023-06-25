using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalTracker
{
    private List<Goal> _listOfGoals;
    private List<int> _listOfPoints; //list that stores the accumulated points throughout the session

    private int _overallPoints;

    public GoalTracker()
    {
        List<Goal> listOfGoals = new List<Goal>();
        _listOfGoals = listOfGoals;

        List<int> listOfPoints = new List<int>();
        _listOfPoints = listOfPoints;

        _overallPoints = 0; //set to 0 by default

    }

    public void AddGoal(Goal newGoal)
    {
        _listOfGoals.Add(newGoal);
    }

    public void ListGoals() //displays all of the goals in the goal tracker
    {
        //display goals only if list is not empty    
        if (_listOfGoals.Count > 0)
        { 
            foreach (Goal goals in _listOfGoals)
            {
                int index = _listOfGoals.IndexOf(goals);
                int goalNumber = index + 1;

                Console.WriteLine($"{goalNumber}. {goals.DisplayGoal()}");
            
            }
        }

        //if empty, raise the error
        else
        {
            Console.WriteLine("You currently do not have any goals to accomplish!");
            Console.WriteLine("Please create new goals or load a file.");
        }
    }

    private void CalculateOverallPoints()
    {
        int sum = _listOfPoints.Sum();

        _overallPoints = sum; //update the overallpoints to the calculated sum
    }

    public void DisplayOverallPoints()
    {
        Console.WriteLine($"           You have {_overallPoints} points.");

    }

    public void MarkComplete() //record or update a goal status
    {
        try 
        {
            int listCount = _listOfGoals.Count; //get object count to be used for conditional statements
            
            //diplay goal names as submenu
            foreach (Goal goals in _listOfGoals)
            {
                int index = _listOfGoals.IndexOf(goals);
                int goalNumber = index + 1;

                string goalName = goals.GetGoalName();

                //displays each goal as 1. Goal Name, 2. Goal name, etc.
                Console.WriteLine($"{goalNumber}. {goalName}");

            }

            Console.Write("Which goal did you accomplish? ");
            int userInput = int.Parse(Console.ReadLine());
          

            if (userInput > 0 && userInput <= listCount) //if user choice is within the list
            {
                
                Goal selectedGoal = _listOfGoals[userInput-1];
                bool completionStatus = selectedGoal.IsComplete();

                if (completionStatus) //if already completed or _isCompleted = True
                {
                    Console.WriteLine();
                    Console.WriteLine("You have already completed this goal!");
                    Console.WriteLine("Please choose a different goal to accomplish.");
                }

                else //if _isCompleted = False, record event and update points
                {
                    //returns points and will also update completion status for the selected goal where userInput-1 is the zero based index of the Goal object.
                    int pointsGained = selectedGoal.RecordEvent(); 

                    _listOfPoints.Add(pointsGained); //add points gained to the list of points

                    CalculateOverallPoints(); //get the sum of all points in the list, and update the value of _overallPoints

                    Console.WriteLine();
                    Console.WriteLine($"Congratulations! You have earned {pointsGained} points.");
                    Console.WriteLine($"You now have a total of {_overallPoints} points.");
                }
                

            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("You have entered an invalid option.");
                Console.WriteLine("Please choose a number within the list of options.");
            }

        }

        catch (FormatException)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Input. Please enter a valid integer");
        }


    }

    public void SaveFile()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        Console.WriteLine();

        if (File.Exists(filename))

        {
            Console.WriteLine("\nFile already exists!");
            Console.Write($"Are you sure you want to overwrite {filename}? Enter (y) to continue, any key to cancel : ");
            string userInput = Console.ReadLine().ToLower(); //will work whether upper case Y or lowercase y is used

            if (userInput == "y")

            {
               ExecuteSaveFile(filename);
            }

            else
            {
                Console.WriteLine("File not saved.");
            }
        }

        else
        {
            ExecuteSaveFile(filename);

        }

    }

    //actual save file method that can be reused
    private void ExecuteSaveFile(string filename)
    {
        Console.WriteLine($"Your file {filename} was saved successfully!");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_overallPoints); //Write overall points on the first line
            
            foreach (Goal goals in _listOfGoals)
            {
                outputFile.WriteLine(goals.GetStringRepresentation()); //begin writing on the second line
            }
        }
    }

    //update the contents of the _listOfGoals with previousListOfGoals for loading saved files
    public void SetListOfGoals(List<Goal> previousListOfGoals)
    {
        _listOfGoals = previousListOfGoals;
    }

    public List<Goal> LoadFile()
    {
        List<Goal> savedGoals = new List<Goal>();

        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename)) //Load successfully if file exists
        {
            Console.WriteLine();
            Console.WriteLine($"Your file {filename} was loaded successfully!");

            string [] lines = System.IO.File.ReadAllLines(filename);

            if(lines.Length > 0) //if the file is not empty
            {
                string firstLine = lines[0]; //first line is the overallpoints saved
                _overallPoints = int.Parse(firstLine); //update the value of _overallPoints to the saved points value
                _listOfPoints.Add(_overallPoints);
            

                for (int i = 1; i < lines.Length; i++) //iterate through all the lines starting from 2nd line
                {
                    //each line on the file will look like DerivedClass/GoalType:{_goalName}~~{_goalDescription}~~{_goalPoints}~~{etc}

                    string line = lines[i];
                    
                    string [] parts = line.Split(":"); //separate the GoalType from its attributes

                    string goalType = parts[0];
                    string attributes = parts[1];

                    if (goalType == "SimpleGoal")
                    {
                        string [] attribute = attributes.Split("~~");

                        string goalName = attribute[0];
                        string goalDescription = attribute[1];
                        int goalPoints = int.Parse(attribute[2]);
                        bool isCompleted =bool.Parse(attribute[3]);
                        

                        SimpleGoal newGoal = new SimpleGoal(goalName, goalDescription, goalPoints, isCompleted);

                        savedGoals.Add(newGoal);
                    }

                    else if (goalType == "EternalGoal")
                    {
                        string [] attribute = attributes.Split("~~");

                        string goalName = attribute[0];
                        string goalDescription = attribute[1];
                        int goalPoints = int.Parse(attribute[2]);
                        
                        EternalGoal newGoal = new EternalGoal(goalName, goalDescription, goalPoints);

                        savedGoals.Add(newGoal);

                    }

                    else //goalType is ChecklistGoal
                    {
                        string [] attribute = attributes.Split("~~");

                        string goalName = attribute[0];
                        string goalDescription = attribute[1];
                        int goalPoints = int.Parse(attribute[2]);
                        int bonusPoints = int.Parse(attribute[3]);
                        int targetAmount = int.Parse(attribute[4]);
                        int targetAccomplished = int.Parse(attribute[5]);
                        bool isCompleted = bool.Parse(attribute[6]);

                        ChecklistGoal newGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, bonusPoints, targetAmount, targetAccomplished, isCompleted);

                        savedGoals.Add(newGoal);
                    }

                    
                }

                

            }

            return savedGoals;

        }

        else //handle file doesn't exist error so program doesn't crash
        {
            Console.WriteLine("\nERROR!");
            Console.WriteLine("File doesn't exist. Please create it or load a different file");

            return savedGoals; //returns nothing
        }

    }

    public void ResetOverallPoints()
    {
        _overallPoints = 0;
        _listOfPoints.Clear();
    }

    //stretch challenge
    public void DisplayRank()
    {
        if (_overallPoints >= 0 && _overallPoints <= 150)
        {
            RankLoadingMessage();
            Console.Write("   + * * LVL 1 : NOVICE ACHIEVER * * +       ");
            Console.WriteLine("\n        Embark on your goal journey");

        }

        else if (_overallPoints >= 151 && _overallPoints <= 600)
        {
            RankLoadingMessage();
            Console.Write("   + * *   LVL 2 : RISING STAR   * * +       ");
            Console.WriteLine("\n   Making steady progress towards sucess");

        }

        else if (_overallPoints >= 601 && _overallPoints <= 1300)
        {
            RankLoadingMessage();
            Console.Write("   + * *   LVL 3 : TRAILBLAZER    * * +       ");
            Console.WriteLine("\n    Push boundaries, reach new heights");

        }

        else if (_overallPoints >= 1301 && _overallPoints <= 2000)
        {
            RankLoadingMessage();
            Console.Write("   + * *   LVL 4 : GOAL MASTER   * * +       ");
            Console.WriteLine("\n    Achieveing remarkable milestones");

        }

        else if (_overallPoints >= 2001 && _overallPoints <= 3000)
        {
            RankLoadingMessage();
            Console.Write("   + * * LVL 5 : ELITE PERFORMER * * +       ");
            Console.WriteLine("\n     Reaching goals with confidence");

        }

        else if (_overallPoints >= 3001 && _overallPoints <= 4500)
        {
            RankLoadingMessage();
            Console.Write("   + * * LVL 6 : PRODIGY PURSUER * * +       ");
            Console.WriteLine("\n     Unleashing your full potential");

        }

        else if (_overallPoints >= 4501 && _overallPoints <= 6500)
        {
            RankLoadingMessage();
            Console.Write("     + * * LVL 7 : VICTORY VOYAGER * * +       ");
            Console.WriteLine("\nConquering challenges, surpassing expectations");

        }

        else if (_overallPoints >= 6501 && _overallPoints <= 9500)
        {
            RankLoadingMessage();
            Console.Write("   + * * LVL 8 : SUPREME STRIVER * * +       ");
            Console.WriteLine("\n   Pursuing the heights of goal mastery");

        }

        else if (_overallPoints >= 9501 && _overallPoints <= 15000)
        {
            RankLoadingMessage();
            Console.Write("   + * * LVL 9 : LEGENDARY ACHIEVER * * +       ");
            Console.WriteLine("\n    Attaining the pinnacle of achievement");

        }

        else if (_overallPoints >= 15001)
        {
            RankLoadingMessage();
            Console.Write("   + * * LVL 10 : ULTIMATE GOAL CONQUEROR * * +       ");
            Console.WriteLine("\n        Defying limits, setting records!");

        }
    }

    private void RankLoadingMessage()
    {
        Console.WriteLine();
        Console.Write("   + * * loading Goal Tracker rank * * +");
        Console.SetCursorPosition(0, Console.CursorTop);
        Thread.Sleep(1000);
        Console.Write("   + + + - - - - - - - - - - -  + + +   ");
        Console.SetCursorPosition(0, Console.CursorTop);
        Thread.Sleep(1000);
    }


}

