using System;

class Program
{
    static void Main(string[] args)
    {
        
        string runAgain = "y";
        
        Console.WriteLine("Prep 5: Test Program for Functions");

        while (runAgain == "y")

        {

            DisplayWelcome();
        
            string userName = PromptUserName();
            int favNumber = PromptUserNumber();
            int squaredNumber = SquareNumber(favNumber);

            DisplayResult(userName, squaredNumber);

            Console.Write("\nPress y to run the program again, or any key to exit: ");
            runAgain = Console.ReadLine();

        }


        static void DisplayWelcome()
        {
            Console.WriteLine("\nWelcome to the Program!\n");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int favNumber = int.Parse(Console.ReadLine());
            return favNumber;

        }

        static int SquareNumber(int favNumber)
        {
            int squaredNumber = favNumber * favNumber;
            return squaredNumber;

        }

        static void DisplayResult(string userName, int squaredNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");

        }
    }
}