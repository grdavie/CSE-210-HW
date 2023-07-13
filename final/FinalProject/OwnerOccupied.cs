using System; 

public class OwnerOccupied : Loan 
{
    public OwnerOccupied(double securityValue, double depositAmount, int loanTerm)
    : base(securityValue, depositAmount, loanTerm)
    {
        //same constructor as base class
    }
    public override void SetInterestRate()
    {
        if(_lvr > 0.70 && _lvr <= 0.80) //lvr between 71-80 
        {
            _interestRate = 0.0634; //6.34% rate
        }

        else if(_lvr > 0.60 && _lvr <= 0.70) //lvr between 61-70
        {
            _interestRate = 0.0604; //6.04% rate
        }

        else if(_lvr <= 0.60) //LVR 60 and under
        {
            _interestRate = 0.0594; //5.94% rate
        }
    }


}