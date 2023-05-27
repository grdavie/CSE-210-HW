using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        
        DisplayHeader();

        //User Inputs
        Console.WriteLine("Please provide the details for the Scripture you want to memorise");
        Console.Write("Book: ");
        string book = Console.ReadLine();
        Console.Write("Chapter: ");
        string chapterNumber = Console.ReadLine();
        Console.WriteLine("For multiple verses, separate them with a dash (e.g. 3-6)");
        Console.Write("Verse: ");
        string verse = Console.ReadLine();
        Console.Write("Scripture text: ");
        string scriptureText = Console.ReadLine();

        string verseNumber = "";
        string endVerse = "";

        if (verse.Contains("-")) //if there are multiple verses, store them as verseNumber and endVerse
        {
            string [] verses = verse.Split("-"); //{verse}-{endverse}

            verseNumber = verses[0];
            endVerse = verses[1];

            DisplayHeader();

            Reference reference = new Reference(book, chapterNumber, verseNumber, endVerse);
            Scripture scripture = new Scripture(reference, scriptureText);
            
            InitiateProgram(scripture, reference); 
            

        }

        else //single verse
        {

            DisplayHeader();

            Reference reference = new Reference(book, chapterNumber, verse);
            Scripture scripture = new Scripture(reference, scriptureText);

            InitiateProgram(scripture, reference);           


        }


        //Program Methods

        static void DisplayHeader() //clear console plus header
        {
            Console.Clear();

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Welcome to the Scripture Memoriser Program");
            Console.WriteLine("--------------------------------------------\n");
        }

        static void DisplayPrompt1() //beginning prompt
        {
            Console.WriteLine("\nPress ENTER to continue or ESC to quit");
        }

        static void DisplayPrompt2() //prompt with restart option
        {
            Console.WriteLine("\nPress ENTER to continue, BACKSPACE to restart, or ESC to quit");
        }

        static void InitiateProgram(Scripture scripture, Reference reference) //main program body to make it reusable
        {
            bool isTextHidden = scripture.IsCompletelyHidden(); //true = hidden, false = visible
            Console.WriteLine(scripture.GetRenderedText()); //display scripture with no hidden words
            
            DisplayPrompt1();

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

                    DisplayHeader();
                    
                    //replace console text with the updated scripture with hidden words
                    Console.WriteLine(scripture.GetRenderedText()); 

                    DisplayPrompt2();

                }
                
                //additional argument to handle last round if there will be 2 leftover words
                //last 5 words will disappear at the same time
                if ((pressedKey.Key == ConsoleKey.Enter) && (wordObjectCount - indexCount == 2)) 
                {
                    scripture.HideWords();
                    scripture.HideWords();

                    DisplayHeader();

                    //replace console text with the updated scripture with hidden words
                    Console.WriteLine(scripture.GetRenderedText()); 

                    DisplayPrompt2();

                    isTextHidden = scripture.IsCompletelyHidden(); //ends the while loop by updating value to true

                }

                //additional argument to handle last round if there is 1 word left
                //last 4 words will disappear at the same time
                if ((pressedKey.Key == ConsoleKey.Enter) && (wordObjectCount - indexCount == 1)) 
                {
                    scripture.HideWords();

                    DisplayHeader();

                    //replace console text with the updated scripture with hidden words
                    Console.WriteLine(scripture.GetRenderedText()); 

                    DisplayPrompt2();

                    isTextHidden = scripture.IsCompletelyHidden(); //ends the while loop by updating the value to true

                }

                if ((pressedKey.Key == ConsoleKey.Enter) && (wordObjectCount == indexCount)) //end loop when all words are hidden
                {

                    break;
                } 

                else if (pressedKey.Key == ConsoleKey.Escape) //end loop if escape key is pressed
                {
                
                    break;
                }

                else if (pressedKey.Key == ConsoleKey.Backspace) //restart program if backspace is pressed
                {
                    scripture.RestartProgram();

                    DisplayHeader();

                    //replace console text with the updated scripture with hidden words
                    Console.WriteLine(scripture.GetRenderedText()); 

                    DisplayPrompt2();

                    isTextHidden = scripture.IsCompletelyHidden();
                }

            }

            Console.WriteLine("\nGood Bye!\n");
        }

    }
    



}