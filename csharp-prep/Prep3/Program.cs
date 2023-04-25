using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prep 3: Guess the Magic Number\n");
        string runAgain = "y";

        while (runAgain == "y")
        {
            //Console.Write("What is the magic number? ");
            //string numberInput = Console.ReadLine(); 
            //int magicNumber = int.Parse(numberInput);

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            int guess = 0;
            int guessCount = 1;

            while (magicNumber != guess)
            {

                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);

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

                guessCount = guessCount + 1;

            }

            if (guessCount == 1)
            {
                Console.WriteLine($"It took you {guessCount} guess.");
            }

            else
            {
                Console.WriteLine($"It took you {guessCount} guesses.");
            }

            Console.WriteLine("Would you like to keep going? (y/n) ");
            runAgain = Console.ReadLine();
        }
    }
}