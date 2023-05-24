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
        //int indexCount = scripture.GetListCount();

        Console.WriteLine("\nPress ENTER to continue or press ESC to quit");
        
        
        while (isTextHidden == false) //while word._hidden for every object in the word list is not all true, loop
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
    
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                
                //if (indexCount % 3 == 0)
                //{
                scripture.HideWords();
                scripture.HideWords();
                scripture.HideWords();  //hide three unique words at a time

                Console.Clear(); //clear the console to reprint everything

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                Console.WriteLine(scripture.GetRenderedText()); //replace console text with the updated scripture with hidden words

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

                    //indexCount = scripture.GetListCount();

                //}

                //else
                //{
                //    scripture.HideWords();

                //    Console.Clear();
//
                //    Console.WriteLine("--------------------------------------------");
                //    Console.WriteLine("Welcome to the Scripture Memoriser Program");
                //    Console.WriteLine("--------------------------------------------\n");

                //    Console.WriteLine(scripture.GetRenderedText()); 

                //    Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

                //}

            }

            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                break;
            }

        }

        Console.WriteLine("\nGood Bye!\n");

        


    }
}