using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prep 3: Guess the Magic Number\n");

        Console.Write("What is the magic number? ");
        string numberInput = Console.ReadLine(); 

        Console.Write("What is your guess? ");
        string guessInput = Console.ReadLine();

        int magicNumber = int.Parse(numberInput);
        int guess = int.Parse(guessInput);

        if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }

        else if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }

        else
        {
            Console.WriteLine("You guessed it!");
        }


    }
}