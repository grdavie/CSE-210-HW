using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompt = ReadfromFile();

    public static List<string> ReadfromFile()
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

    
    public string ReturnRandomPrompt(List<string> _prompt)
    {
        Random randNum = new Random();
        int randIndex = randNum.Next(_prompt.Count);

        string randomPrompt = _prompt[randIndex];

        return randomPrompt;
    }
}