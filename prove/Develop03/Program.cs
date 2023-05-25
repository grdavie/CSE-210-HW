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
        Console.WriteLine(scripture.GetRenderedText()); //display scripture with no hidden words
        

        Console.WriteLine("\nPress ENTER to continue or press ESC to quit");
        
        
        while (isTextHidden == false) //while word._hidden for every object in the word list is not all true, loop
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            int indexCount = scripture.GetIndexCount();
            int wordObjectCount = scripture.GetWordObjectCount();
    
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                
                scripture.HideWords();
                scripture.HideWords();
                scripture.HideWords();  //hide three unique words at a time

                indexCount = scripture.GetIndexCount();

                Console.Clear(); //clear the console to reprint everything

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                Console.WriteLine(scripture.GetRenderedText()); //replace console text with the updated scripture with hidden words

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

                //isTextHidden = scripture.IsCompletelyHidden();

            }

            if ((pressedKey.Key == ConsoleKey.Enter) && (wordObjectCount - indexCount < 3))
            {
                scripture.HideWords();

                Console.Clear(); //clear the console to reprint everything

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                Console.WriteLine(scripture.GetRenderedText()); //replace console text with the updated scripture with hidden words

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

                isTextHidden = scripture.IsCompletelyHidden();
            }

            else if (pressedKey.Key == ConsoleKey.Escape)
            {
            
                break;
            }

        }

        Console.WriteLine("\nGood Bye!\n");

        


    }
}