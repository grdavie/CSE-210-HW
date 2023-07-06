using System;

public abstract class Loan
{
    protected int _loanAmount;
    protected int _securityValue;
    protected int _depositAmount;
    protected int _loanTerm; //in months
    protected double _interestRate; //expressed as a decimal
    protected double _assessmentRate; //7.30% default or if interest is higher than 7.30%, add 2% e.g. 9% IR will have 11% assessment rate
    protected double _lvr; //loan to value ratio expressed as a decimal e.g 80% = 0.80
    

    public Loan(int securityValue, int depositAmount, int loanTerm) //loanTerm in years
    {
        _securityValue = securityValue;
        _depositAmount = depositAmount;
        _loanAmount = _securityValue - _depositAmount;
        _loanTerm = loanTerm * 12;

        _lvr = _loanAmount / _securityValue;

    }

    public abstract void SetAssessmentRate();

    public abstract void SetInterestRate();
    public abstract float CalculateMonthlyRepayments();

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

    public int GetPrincipal()
    {
        return _loanAmount;
    }

    public void DisplayLoanDetails()
    {
        int LVR = Convert.ToInt32(_lvr * 100);
        float repayment = CalculateMonthlyRepayments();
        
        
        Console.WriteLine($"> Property Value: ${_securityValue}");
        Console.WriteLine($"> Loan Amount Required: ${_loanAmount}");
        Console.WriteLine($"> LVR: {LVR}%");
        Console.WriteLine($"> Loan Term: {_loanTerm} months ({_loanTerm/12} yrs)");
        Console.WriteLine($"> Applicable Interest Rate: {_interestRate}");
        Console.WriteLine($"> Indicative Monthly Repayment: ${repayment}");
      
        //assessment rate does not need to be disclosed
    }
}