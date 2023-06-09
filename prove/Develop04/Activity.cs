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

    //start message template
    public void DisplayStartMessage()
    {
        
        int duration = -1;
        
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        //limiting duration input to multiples of 10 starting with 10 seconds
        while (duration < 10 || duration % 10 != 0)
        {
      
            try
            {
                
                //Get user duration input within set limitations
                Console.Write("How long, in seconds, would you like for your duration (minimum 10, in multiples of 10)? ");
                duration = int.Parse(Console.ReadLine());

                //restart loop if user inputs number less than 10
                if (duration < 10)
                {
                    Console.WriteLine("Please set duration to no less than 10 seconds");
                    Console.WriteLine();

                }

                //restart loop if user inputs a number that is not a multiple of 10
                else if (duration % 10 != 0)
                {
                    Console.WriteLine("Please select a duration in multiples of 10 (e.g. 10, 20, 30, etc)");
                    Console.WriteLine();
                }

                //break loop if input is a multiple of 10 and is equal or greater than 10
                else
                {
                  break;
                }
            
            }

            //exception handling if user inputs non-integer
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        }

        //set the value for _duration attribute
        SetDuration(duration);
      
    }

    //helper method to set duration 
    private void SetDuration(int duration)
    {   
        _duration = duration;
    }

    //end message template
    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");

        PauseSpinner(5); //5 second spinner

        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_activityName} Activity.");

        PauseSpinner(5); //5 second spinner

        Console.Clear();

    }

    public static void PauseSpinner(int spinnerDuration) //pause while displaying a spinner for a specified duration
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

    public static void PauseCountdownTimer(int timerDuration, string timerMessage) //pausing while showing a countdown timer, user can set timer duration and message before the countdown
    {
        int duration = timerDuration;
        string message = timerMessage;

        for (int i = timerDuration; i > 0; i--)
        {
            //set cursor position so each loop overwrites on top of the previous loop
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"{message} {i}"); //e.g. Timer starts in... 5
            Thread.Sleep(1000);
        }

        //set cursor position so if duration is complete, console will still overwrite on the same line
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"{message}    "); //replace with the original message with no timer e.g. Timer starts in...   
    
        
        //for (int i = timerDuration; i > 0; i--)
        //{
        //    Console.Write(i);
        //    Thread.Sleep(1000);
        //    Console.Write("\b\b \b");
        //}

        //Console.Write("Now!");

    }

    public void DisplayGetReadySpinner()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(5); //5 second spinner
        Console.WriteLine();
    }







}
