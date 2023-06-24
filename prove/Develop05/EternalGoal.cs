using System;

public class EternalGoal : Goal
{

    public EternalGoal(string goalName, string goalDescription, int goalPoints)
        : base(goalName, goalDescription, goalPoints)
    
    {
        //empty constructor
    }

    public override int RecordEvent()
   {
        //Console.WriteLine($"Congratulations! You have earned {_goalPoints}");

        return _goalPoints;
   }

    public override bool IsComplete()
    {
        _isCompleted = false; //always false
        
        return _isCompleted;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_goalName}~~{_goalDescription}~~{_goalPoints}";
    }

}