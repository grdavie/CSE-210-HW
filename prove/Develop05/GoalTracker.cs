using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalTracker
{
    private List<Goal> _listOfGoals;
    private List<int> _listOfPoints;

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
        foreach (Goal goals in _listOfGoals)
        {
            int index = _listOfGoals.IndexOf(goals);
            int goalNumber = index + 1;

            Console.WriteLine($"{goalNumber}. {goals.DisplayGoal()}");
           
        }
    }

    private void CalculateOverallPoints()
    {
        int sum = _listOfPoints.Sum();

        _overallPoints = sum;
    }

    public void DisplayOverallPoints()
    {
        Console.WriteLine($"You have {_overallPoints} points.");

    }

    public void MarkComplete() //record or update a goal status
    {
        try 
        {
            int listCount = _listOfGoals.Count;
            
            //diplay goal names as submenu
            foreach (Goal goals in _listOfGoals)
            {
                int index = _listOfGoals.IndexOf(goals);
                int goalNumber = index + 1;

                string goalName = goals.GetGoalName();

                Console.WriteLine($"{goalNumber}. {goalName}");

            }

            Console.Write("Which goal did you accomplish? ");
            int userInput = int.Parse(Console.ReadLine());

            if (userInput > 0 && userInput <= listCount) //if user choice is within the list
            {
                //returns points and will also update completion status for the selected goal where userInput-1 is the zero based index of the Goal object.
                int pointsGained = _listOfGoals[userInput-1].RecordEvent(); 

                _listOfPoints.Add(pointsGained); //add points gained to the list of points

                CalculateOverallPoints(); //get the sum of all points in the list, and update the value of _overallPoints

                Console.WriteLine($"Congratulations! You have earned {pointsGained}");
                Console.WriteLine($"You now have {_overallPoints}.");

            }

            else
            {
                Console.WriteLine("You have entered an invalid option.");
                Console.WriteLine("Please choose a number within the list of options.");
            }

        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid Input. Please enter a valid integer");
        }


    }

    public void SaveFile()
    {
        Console.Write("What is the fileanme? ");
        string filename = Console.ReadLine();

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

                        ChecklistGoal newGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, bonusPoints, targetAmount, targetAccomplished);

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




}

