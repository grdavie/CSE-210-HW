using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your grade? ");
        string userInput = Console.ReadLine();

        int grade = int.Parse(userInput);
        string letter = "";

        if (grade >= 90)
        {
           letter = "A";
        }

        else if (grade >= 80)
        {
            letter = "B";
        }

        else if (grade >= 70)
        {
            letter = "C";
        }

        else if (grade >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the subject!");
        }

        else
        {
            Console.WriteLine("Sorry! Retake the subject and do better on the next semester!");
        }
    }
}