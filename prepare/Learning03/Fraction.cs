using System;

public class Fraction
{
    private int _top;
    private int _bottom;


    //Constructors
    public Fraction() //default to 1/1
    {
        _top = 1;
        _bottom = 1;
    }

    
    public Fraction(int wholeNumber) //default to wholeNumber/1
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom) //default to top/bottom
    {
        _top = top;
        _bottom = bottom;
    }


    //Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    //Method to display attributes as fraction string
    public string GetFractionString()
    {
        string fraction = _top + "/" + _bottom;
        
        return fraction;
    }

    //Method to display attributes as double decimal value
    public double GetDecimalValue()
    {
        double decimalValue = (double)_top / (double)_bottom;

        return decimalValue;
    }

}