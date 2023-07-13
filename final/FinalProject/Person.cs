using System;

public class Person
{
    protected string _name;
    protected string _phoneNumber;
    protected string _emailAddress;

    public Person(string name, string phoneNumber, string emailAddress)
    {
        _name = name;
        _phoneNumber = phoneNumber;
        _emailAddress = emailAddress;
    }

    public void DisplayContactDetails() //display base class information
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{_name} | {_phoneNumber} | {_emailAddress}");
        Console.ResetColor();

    }
}