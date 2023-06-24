using System;

public class SimpleGoal : Goal
{

    public SimpleGoal(string goalName, string goalDescription, int goalPoints)
        : base(goalName, goalDescription, goalPoints)
    
    {
        //empty constructor
    }
   public override int RecordEvent()
   {
        _isCompleted = true; //change status to completed
        //Console.WriteLine($"Congratulations! You have earned {_goalPoints}");

        return _goalPoints;
   }

    public override bool IsComplete()
    {
        return _isCompleted;
    }



}