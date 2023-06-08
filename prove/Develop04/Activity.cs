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
        
        int duration = -1;
        
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (duration < 10 || duration % 10 != 0)
        {
      
            try
            {
                Console.Write("How long, in seconds, would you like for your duration (minimum 10, in multiples of 10)? ");
                duration = int.Parse(Console.ReadLine());

                if (duration < 10)
                {
                    Console.WriteLine("Please set duration to no less than 10 seconds");
                    Console.WriteLine();

                }

                else if (duration % 10 != 0)
                {
                    Console.WriteLine("Please select a duration in multiples of 10 (e.g. 10, 20, 30, etc)");
                    Console.WriteLine();
                }

                else
                {
                  break;
                }
            
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        }

        SetDuration(duration);
      
    }

    private void SetDuration(int duration)
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

        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_activityName} Activity.");

        PauseSpinner(5);

        Console.Clear();

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

    public static void PauseCountdownTimer(int timerDuration, string timerMessage) //pausing while showing a countdown timer
    {
        int duration = timerDuration;
        string message = timerMessage;

        for (int i = timerDuration; i > 0; i--)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"{message} {i}");
            Thread.Sleep(1000);
        }

        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"{message}    ");
    
        
        //for (int i = timerDuration; i > 0; i--)
        //{
        //    Console.Write(i);
        //    Thread.Sleep(1000);
        //    Console.Write("\b\b \b");
        //}

        //Console.Write("Now!");

    }







}


//List as many responses as you can to the following prompt:
// --- Random Question Prompt ---
//You may begin in: (countdown from 5)
// > {console readline} *add to a list of answers
// > repeat until you run out of time
// at the end of the timer display: You listed {#} items!

//clear console to keep the screen clean each time an activity finishes or a new menu loads