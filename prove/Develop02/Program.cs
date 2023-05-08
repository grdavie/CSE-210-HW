using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Journal Program!");
        Console.WriteLine("\nPlease select one of the following choices: ");
        Console.WriteLine("1.Write\n2.Display\n3.Load\n4.Save\n5.Quit");
        Console.Write("What would you like to do? ");
        int userChoice = int.Parse(Console.ReadLine());

        //Console.WriteLine(userChoice);
        
        
        PromptGenerator journalPrompt = new PromptGenerator();
        List<string> listOfPrompts = new List<string>();

        listOfPrompts = journalPrompt._prompt;

        Console.WriteLine(journalPrompt.ReturnRandomPrompt(listOfPrompts));
        

    }
}