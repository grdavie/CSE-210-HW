using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prep 4: Number Series \n");

        List<int> numbers = new List<int>();

        int numberInput = -1; 
        int sum = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");


        //Add numbers to the list:
        while (numberInput != 0)
        {

            Console.Write("Enter number: ");
            numberInput = int.Parse(Console.ReadLine());
            
            if (numberInput != 0)
            {
                numbers.Add(numberInput);
            }
        }

        //Compute for the sum of the numbers inside the list
        foreach (int number in numbers)
        {
            sum += number;

        }

        Console.WriteLine($"The sum is: {sum}");

        //Compute for the average based on the sum and total number count 
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //Find the max number in the list

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}"); 

    }
}