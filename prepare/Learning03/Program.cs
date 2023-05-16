using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nLearning 03: Encapsulation\n");

        //Step 4.1
        //Fraction f1 = new Fraction();
        //Fraction f2 = new Fraction(6);
        //Fraction f3 = new Fraction(6, 7);

        //Step 4.2???
        //Console.WriteLine(f1.GetTop());
        //Console.WriteLine(f1.GetBottom());
        //Console.WriteLine(f2.GetTop());
        //Console.WriteLine(f2.GetBottom());
        //Console.WriteLine(f3.GetTop());
        //Console.WriteLine(f3.GetBottom());

        //Step 5.2 - Set (Replace the values of the constructors above)
        //f1.SetTop(2);
        //f1.SetBottom(3);
        //f2.SetTop(4);
        //f2.SetBottom(5);
        //f3.SetTop(8);
        //f3.SetBottom(3);


        //Step 5.2 - Get
        //Console.WriteLine(f1.GetTop());
        //Console.WriteLine(f1.GetBottom());
        //Console.WriteLine(f2.GetTop());
        //Console.WriteLine(f2.GetBottom());
        //Console.WriteLine(f3.GetTop());
        //Console.WriteLine(f3.GetBottom());

        //Step 6.2
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());



    }
}