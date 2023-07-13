using System;

public abstract class Loan
{
    protected double _loanAmount;
    protected double _securityValue;
    protected double _depositAmount;
    protected int _loanTerm; //in months
    protected double _interestRate; //expressed as a decimal
    protected double _assessmentRate; //7.30% default or if interest is higher than 6%, add 2.5% e.g. 6.5% IR will have 9% assessment rate
    protected double _lvr; //loan to value ratio expressed as a decimal e.g 80% = 0.80
    

    public Loan(double securityValue, double depositAmount, int loanTerm) //loanTerm in years
    {
        _securityValue = securityValue;
        _depositAmount = depositAmount;
        _loanAmount = _securityValue - _depositAmount;
        _loanTerm = loanTerm * 12;

        _lvr = (double)_loanAmount / securityValue; //must be a minimum of 80 or requires a 20% of security value deposit

    }

    //rates are different between O/O and INV based on their LVR tiers
    public abstract void SetInterestRate();

    //7.30% default or if interest is higher than 6%, add 2.5% e.g. 6.5% IR will have 9% assessment rate
    public void SetAssessmentRate()
    {
        if(_interestRate <= 0.060)
        {
            _assessmentRate = 0.073; //7.30%
        }

        else //if greater than 0.060
        {
            _assessmentRate = _interestRate + 0.025;
        }
    }

    public double CalculateMonthlyRepayments()
    {
        // A = P * ( (r(1+r)**n) / ((1+r)**n) -1 )
        //A: Periodic payment amount
        //P: Principal loan amount
        //r: Periodic interest rate (expressed as a decimal)
        //n: Number of periods

        double P = _loanAmount;
        double r = _assessmentRate / 12; //the higher assessment rate will be used instead of interest rate to provide a buffer
        int n = _loanTerm;

        double A = P * ( (r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1)); 

        return A;
        
    }


    public double GetAssessmentRate()
    {
        return _assessmentRate;
    }

    public double GetInterestRate()
    {
        return _interestRate;
    }

    public int GetLoanTerm()
    {
        return _loanTerm;
    }

    public double GetPrincipal()
    {
        return _loanAmount;
    }


    public void DisplayLoanDetails()
    {
        
        double LVR = _lvr * 100;
        double interest = _interestRate * 100;
        
        //string formattedLVR = LVR.ToString("F2");
        int repayment = (int)Math.Round(CalculateMonthlyRepayments()); //round to the nearest whole number
        string formattedInterest = interest.ToString("F2");
        
        
        Console.WriteLine($"     > Property Value: ${_securityValue}");
        Console.WriteLine($"     > Loan Amount Required: ${_loanAmount}");
        Console.WriteLine($"     > LVR: {LVR}%");
        Console.WriteLine($"     > Loan Term: {_loanTerm} months ({_loanTerm/12} yrs)");
        Console.WriteLine($"     > Applicable Interest Rate: {formattedInterest}%");
        Console.WriteLine($"     > Indicative Monthly Repayment: ${repayment}^");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"\n^ - The calculated indicative monthly repayment is based on an assessment rate of {_assessmentRate * 100}%");
        Console.ResetColor();
      
        
    }
}