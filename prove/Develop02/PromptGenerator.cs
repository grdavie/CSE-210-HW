using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompt = ReadfromFile(); //the list that was returned by the ReadFromFile() method
    

    public static List<string> ReadfromFile() //reads the prompts from the text file and returns it as a list
    {
        List<string> prompts = new List<string>();
        string filename = "prompts.txt";

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            prompts.Add(line);
        }

        return prompts;

    }

    
    public string ReturnRandomPrompt(List<string> _prompt) //takes in the list of prompts as its parameter to return a random prompt string
    {
        Random randNum = new Random();
        int randIndex = randNum.Next(_prompt.Count); //returns a non-negative random integer less than the maximum to account for 0 index

        string randomPrompt = _prompt[randIndex]; //prompt randomly selected from the list of prompts using the random index generated

        return randomPrompt;
    }
}