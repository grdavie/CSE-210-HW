using System;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        //empty
    }

    public void DisplayStartMessage()
    {
        
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your duration? ");
        int duration = int.Parse(Console.ReadLine());

        SetDuration(duration);
      
    }

    public void SetDuration(int duration)
    {   
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }


    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");

        PauseSpinner(5);

        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_activityName} Activity");

        PauseSpinner(5);

    }

    public static void PauseSpinner(int spinnerDuration) //pause while displaying a spinner for specified duration
    {
        int i = 0;

        int duration = spinnerDuration;

        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i == duration) //end the loop if index reaches the duration even if not completely done iterating through the objects
            {
                break;
            }

            else if (i >= animationStrings.Count) //end the loop at duration set even if duration is more than the object count (reset loop until duration ends)
            {
                i = 0;
            }

        }

    }

    public static void PauseCountdownTimer(int timerDuration) //pausing while showing a countdown timer
    {
        int duration = timerDuration;

        for (int i = timerDuration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b\b \b");
        }

        Console.Write("Now!");

    }







}



//Breathing Activity
//This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing
//Breathe in...(countdown from 4)
//Now breathe out...(countdown from 6)

//Reflecting Activity
//This activity will help you refelct on the times in your life when you have shown strength and resilience. This will help you recognise the power you have and how you can use it in other aspects of your life. 
//Consider the following prompt:
// --- Random Prompt ---
//When you have something in mind, press enter to continue. (consolekey enter?)

//Now ponder on each of the following questions as they relate to this experience.
//You may begin in: (countdown from 5)
// > Random Question #1? (5 second spinner etc)
// > Random Questions #2? (5 second spinner etc)
// stretch - ensure you get no duplicate questions before you can restart them


//Listing Activity
//This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. 
//List as many responses as you can to the following prompt:
// --- Random Question Prompt ---
//You may begin in: (countdown from 5)
// > {console readline} *add to a list of answers
// > repeat until you run out of time
// at the end of the timer display: You listed {#} items!

//clear console to keep the screen clean each time an activity finishes or a new menu loads