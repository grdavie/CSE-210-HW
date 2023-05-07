using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
        
        PromptGenerator prompt = new PromptGenerator();
        prompt.ReturnRandomPrompt(prompt._prompt);
    

    }
}