using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        
        GoalTracker goalTracker = new GoalTracker();
        
        //for loading files
        List<Goal> listOfPreviousGoals = new List<Goal>();

        int userChoice = -1;
        
        Console.Clear();

        while (userChoice != 6)

        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Welcome to the Goal Tracker Program");
            Console.WriteLine("--------------------------------------------");
            
            Console.WriteLine();
            goalTracker.DisplayOverallPoints();
            Console.WriteLine();

            Console.WriteLine("Menu Options:\n");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Quit\n");
         
            Console.Write("Select a choice from the menu: ");
            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1) //Display submenu + add new goal
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("   1. Simple Goal");
                Console.WriteLine("   2. Eternal Goal");
                Console.WriteLine("   3. Checklist Goal\n");

                Console.Write("Which type of goal would you like to create? ");
                int goalSelected = int.Parse(Console.ReadLine());
                Console.Write("What is the name of your goal? ");
                string goalName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string goalDescription = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int goalPoints = int.Parse(Console.ReadLine());

                if (goalSelected == 1)
                {
                    
                    Console.WriteLine("\nYour goal has been created!");

                    SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints);

                    //Add to the _listOfGoals inside the GoalTracker class
                    goalTracker.AddGoal(simpleGoal);


                }

                else if (goalSelected == 2)
                {
                    Console.WriteLine("\nYour goal has been created!");

                    EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);

                    //Add to the _listOfGoals inside the GoalTracker class
                    goalTracker.AddGoal(eternalGoal);
                }

                else if (goalSelected == 3)
                {
                    
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int targetAmount = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus points for accomplishing this target? ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("\nYour goal has been created!");

                    ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, bonusPoints, targetAmount);

                    //Add to the _listOfGoals inside the GoalTracker class
                    goalTracker.AddGoal(checklistGoal);
                }

                else
                {
                    Console.WriteLine("You have entered an invalid option.");
                    Console.WriteLine("Please choose a number within the list of options.");
                }

                Thread.Sleep(2000);
                Console.Clear();

            }

            else if (userChoice == 2) //list or display all Goals
            {
                goalTracker.ListGoals();

            }

            else if (userChoice == 3) //save as txt file
            {
                goalTracker.SaveFile();

                Thread.Sleep(2000);
                Console.Clear();
            }

            else if (userChoice == 4) //load txt file
            {
                listOfPreviousGoals = goalTracker.LoadFile();
                goalTracker.SetListOfGoals(listOfPreviousGoals);

                Thread.Sleep(2000);
                Console.Clear();

            }

            else if (userChoice == 5) //record event or mark complete
            {
                goalTracker.MarkComplete();

                Thread.Sleep(3000);
                Console.Clear();

            }

        }

        Console.WriteLine();
        Console.WriteLine("Thank you and Good bye!\n");



    }



  

}