using System;

public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _targetAmount;
    private int _targetAccomplished;
    private int _totalPoints;

    public ChecklistGoal(string goalName, string goalDescription, int goalPoints, int bonusPoints, int targetAmount)
        : base(goalName, goalDescription, goalPoints)
    
    {
        _bonusPoints = bonusPoints;
        _targetAmount = targetAmount;
        _targetAccomplished = 0; //default value set to 0 or nothing accomplished yet
        _totalPoints = _goalPoints + _bonusPoints; //base + bonus points

    }

    public ChecklistGoal(string goalName, string goalDescription, int goalPoints, int bonusPoints, int targetAmount, int targetAccomplished)
        : base(goalName, goalDescription, goalPoints)
    
    {
        _bonusPoints = bonusPoints;
        _targetAmount = targetAmount;
        _targetAccomplished = targetAccomplished;
        _totalPoints = _goalPoints + _bonusPoints; //base + bonus points

    }


    public override void DisplayGoal()
    {
        if(_isCompleted == false)
        {
            Console.Write($"[ ] {_goalName} ({_goalDescription}) -- Currently completed: {_targetAccomplished}/{_targetAmount}");
        }

        else //if task is completed, mark it x when displaying
        {
            Console.Write($"[x] {_goalName} ({_goalDescription}) -- Currently completed: {_targetAccomplished}/{_targetAmount}");
        }
    }

   public override int RecordEvent()
   {
        
        UpdateTargetAccomplished();

        _isCompleted = IsComplete();
        
        if(_isCompleted == false)
        {
            //Console.WriteLine($"Congratulations! You have earned {_goalPoints}");

            return _goalPoints;
        }

        else
        {
            //Console.WriteLine($"Congratulations! You have earned {_totalPoints}");

            return _totalPoints;
        }
       
   }

    public override bool IsComplete()
    {
        if (_targetAccomplished == _targetAmount)
        {
            _isCompleted = true;
            
        }

        else
        {
            _isCompleted = false;
        }
        
        return _isCompleted;
    }


    public int GetTotalPoints()
    {
        return _totalPoints;
    }

    private void UpdateTargetAccomplished()
    {
        
        if (_targetAccomplished < _targetAmount) //allow user to update target accomplished value while it's less than target amount
        {
            int targetAccomplished = _targetAccomplished + 1;
            
            _targetAccomplished = targetAccomplished;
        }

        else
        {
            _targetAccomplished = _targetAmount; //target completely accomplished

        }
        
        
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_goalName}~~{_goalDescription}~~{_goalPoints}~~{_bonusPoints}~~{_targetAmount}~~{_targetAccomplished}";
    }


}   
