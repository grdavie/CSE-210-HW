using System;

public class SimpleGoal : Goal
{

    public SimpleGoal(string goalName, string goalDescription, int goalPoints)
        : base(goalName, goalDescription, goalPoints)
    
    {
        //empty constructor
    }

    public SimpleGoal(string goalName, string goalDescription, int goalPoints, bool isCompleted)
        : base(goalName, goalDescription, goalPoints)
    
    {
        _isCompleted = isCompleted;
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

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_goalName}~~{_goalDescription}~~{_goalPoints}~~{_isCompleted}";
    }



}