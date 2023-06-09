using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    //no breathing activity class specific attributes needed

    public BreathingActivity()
    {
        //constructor sets the value for the Activity class protected attributes
        _activityName = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing";

    }

    public void StartBreathingActivity() //initiate the specific breathing activity behaviour
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(5); //5 second spinner
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            
            PauseCountdownTimer(4,"Breathe in..."); //4 second timer
            Console.WriteLine();
            PauseCountdownTimer(6, "Breathe out..."); //6 second timer
            Console.WriteLine();
            Console.WriteLine();
            
        }
    }
}