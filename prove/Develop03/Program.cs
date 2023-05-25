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
            int indexCount = scripture.GetIndexCount(); //initial indexCount will be 0
            int wordObjectCount = scripture.GetWordObjectCount(); //number of word objects inside my list of word objects
    
            if (pressedKey.Key == ConsoleKey.Enter) 
            {
                
                //hide three unique words at a time
                scripture.HideWords();
                scripture.HideWords();
                scripture.HideWords();  

                //updates or increases the indexCount value by 3 each loop
                indexCount = scripture.GetIndexCount(); 

                Console.Clear(); //clear the console to reprint everything

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                
                //replace console text with the updated scripture with hidden words
                Console.WriteLine(scripture.GetRenderedText()); 

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");


            }
            
            //additional argument to handle last round if there will be 2 leftover words
            //last 5 words will disappear at the same time
            if ((pressedKey.Key == ConsoleKey.Enter) && (wordObjectCount - indexCount == 2)) 
            {
                scripture.HideWords();
                scripture.HideWords();

                Console.Clear(); //clear the console to reprint everything

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                //replace console text with the updated scripture with hidden words
                Console.WriteLine(scripture.GetRenderedText()); 

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

                isTextHidden = scripture.IsCompletelyHidden(); //ends the while loop by updating value to true

            }

            //additional argument to handle last round if there is 1 word left
            //last 4 words will disappear at the same time
            if ((pressedKey.Key == ConsoleKey.Enter) && (wordObjectCount - indexCount == 1)) 
            {
                scripture.HideWords();

                Console.Clear(); //clear the console to reprint everything

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Welcome to the Scripture Memoriser Program");
                Console.WriteLine("--------------------------------------------\n");

                //replace console text with the updated scripture with hidden words
                Console.WriteLine(scripture.GetRenderedText()); 

                Console.WriteLine("\nPress ENTER to continue or press ESC to quit");

                isTextHidden = scripture.IsCompletelyHidden(); //ends the while loop by updating the value to true

            }

            else if (pressedKey.Key == ConsoleKey.Escape)
            {
            
                break;
            }

        }

        Console.WriteLine("\nGood Bye!\n");


    }
}