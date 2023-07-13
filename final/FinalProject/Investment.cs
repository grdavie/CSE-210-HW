using System;


public class Investment : Loan
{
    public Investment(double securityValue, double depositAmount, int loanTerm)
    : base(securityValue, depositAmount, loanTerm)
    {
        //same constructor as base class
    }

    public override void SetInterestRate()
    {
        if(_lvr > 0.70 && _lvr <= 0.80) //lvr between 71-80 
        {
            _interestRate = 0.0659; //6.59% rate
        }

        else if(_lvr > 0.60 && _lvr <= 0.70) //lvr between 61-70
        {
            _interestRate = 0.0629; //6.29% rate
        }

        else if(_lvr <= 0.60) //LVR 60 and under
        {
            _interestRate = 0.0619; //6.19% rate
        }
    }

}