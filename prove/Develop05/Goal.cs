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

    public virtual string DisplayGoal()
    {
        if(_isCompleted == false)
        {
            return $"[ ] {_goalName} ({_goalDescription})";
            
        }

        else //if task is completed, mark it x when displaying
        {
            return $"[x] {_goalName} ({_goalDescription})";
        }
        
        
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    //returns a string containing the pieces of data needed for creating a Goal object in a format that can be easily split into parts
    //once loaded from a saved file. E.g. GoalType:{attribute a}~~{attribute b}~~etc;
    public abstract string GetStringRepresentation(); 


    
}   
