using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalTracker
{
    private List<Goal> _listOfGoals;
    private List<int> _listOfPoints;

    private int _overallPoints;

    public GoalTracker(List<Goal> listofGoals)
    {
        List<int> listOfPoints = new List<int>();
        _listOfPoints = listOfPoints;
        _listOfGoals = listofGoals;
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

            Console.WriteLine($"{goalNumber}. ");
            goals.DisplayGoal();
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
        
        int listCount = _listOfGoals.Count;
        
        //diplay goal names as submenu
        foreach (Goal goals in _listOfGoals)
        {
            int index = _listOfGoals.IndexOf(goals);
            int goalNumber = index + 1;

            Console.WriteLine($"{goalNumber}. {goals.GetGoalName()}");

        }

        Console.Write("Which goal did you accomplish? ");
        int userInput = int.Parse(Console.ReadLine());

        if (userInput <= listCount) //if user choice is within the list
        {
            int pointsGained = _listOfGoals[userInput-1].RecordEvent(); //returns points and will also update completion status

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
                Console.WriteLine($"Your file {filename} was saved successfully!");

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Goal goals in _listOfGoals)
                    {
                        outputFile.WriteLine($"{goals.}")
                    }
                }
            }
        }

    }




}

