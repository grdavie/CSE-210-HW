using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Welcome to the Scripture Memoriser Program");
        Console.WriteLine("--------------------------------------------\n");

        //reference class testing
        Reference r1 = new Reference("John", "3", "16"); //constructor 1
        Console.WriteLine(r1.GetReferenceString());
        Reference r2 = new Reference("Proverbs", "3", "5", "6"); //constructor 2
        Console.WriteLine(r2.GetReferenceString());

        //word class testing
        Word w1 = new Word("Hello");
        w1.Show();
        Console.WriteLine(w1.GetRenderedText());
        w1.Hide();
        Console.WriteLine(w1.GetRenderedText());

        Word w2 = new Word("The");
        w2.Hide();
        Console.WriteLine(w2.GetRenderedText());
        w2.Show();
        Console.WriteLine(w2.GetRenderedText());

        //scripture class testing
        string scriptureSample = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        Scripture s1 = new Scripture(r1, scriptureSample);
        Console.WriteLine(s1.GetRenderedText());


    }
}