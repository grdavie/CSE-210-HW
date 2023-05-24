using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Welcome to the Scripture Memoriser Program");
        Console.WriteLine("--------------------------------------------\n");

        //Add a reference
        Reference reference = new Reference("John", "3", "16");

        //Add scripture text
        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        //create Scripture class
        Scripture scripture = new Scripture(reference, scriptureText);
        bool isTextHidden = scripture.IsCompletelyHidden(); //true = hidden, false = visible
        Console.WriteLine(scripture.GetRenderedText());

        Console.WriteLine("\nPress ENTER to continue or press ESC to quit");
        
        
        while (isTextHidden == false)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
    
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                scripture.HideWords();
                scripture.HideWords();
                scripture.HideWords();

                Console.Clear();

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                Console.WriteLine(scripture.GetRenderedText()); 

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

            }

            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                break;
            }

        }

        Console.WriteLine("\nGood Bye!\n");

        


    }
}