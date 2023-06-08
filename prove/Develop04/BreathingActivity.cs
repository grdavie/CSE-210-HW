using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _activityName = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing";

    }

    public void StartBreathingActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            
            PauseCountdownTimer(4,"Breathe in...");
            Console.WriteLine();
            PauseCountdownTimer(6, "Breathe out...");
            Console.WriteLine();
            Console.WriteLine();
            
        }
    }
}