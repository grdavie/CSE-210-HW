using System;

public abstract class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalPoints;
    protected bool _isCompleted;

    public Goal (string goalName, string goalDescription, int goalPoints)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _goalPoints = goalPoints;
        _isCompleted = false; //set status to not completed by default
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual void DisplayGoal()
    {
        if(_isCompleted == false)
        {
            Console.Write($"[ ] {_goalName} ({_goalDescription})");
        }

        else //if task is completed, mark it x when displaying
        {
            Console.Write($"[x] {_goalName} ({_goalDescription})");
        }
        
        
    }

    public string GetGoalName()
    {
        return _goalName;
    }


    
}   
