using System;

public class Applicant : Person
{
    private bool _isSingle;
    private int _dependants;
    private double _netIncome;
    private int _annualLivingCosts;
    private int _creditLimit;

    public Applicant(string name, string phoneNumber, string emailAddress, bool isSingle, int dependants, int baseIncome, int livingCosts, int creditLimit) 
    : base(name, phoneNumber, emailAddress)
    {
        _isSingle = isSingle;
        _dependants = dependants;
        _netIncome = CalcuateNetIncome(baseIncome);
        _annualLivingCosts = livingCosts * 12; //estimated monthly living cost * 12
        _creditLimit = creditLimit;

    }

    private double CalcuateNetIncome(int baseIncome)
    {
        //calculate the net income by using the base annual income (base - income tax payable)
        //create simple calculator based on below AU tax brackets:
            //australian tax brackets:
            //$1-$18,200 = $0 income tax
            //$18,201-$45,000 = 19c for every dollar or 19%; $5,092 if income is 45K
            //$45,001-$120,000 = 32.5c for every dollar or 32.5%; $24,375 additional if income is 120K
            //$120,001-$180,000 = 37c for every dollar or 37%; $22,000 additional if income is 180K
            //$180,001+ = 45c for every dollar or 45%

        double netIncome = 10000; //placeholder
        
        return netIncome; 
    }

    public double GetNetIncome()
    {
        return _netIncome;
    }

    public int GetEstimatedLivingCosts()
    {
        //Compare _annualLivingCosts with default annual expense allowance assumption based on number of dependants and if single or not 
        //as set by the national Household Expenditure Measure (HEM). If _annualLivingCosts is higher, it will override default values. 
        //If lower, default values will be returned instead. 
            //Number of dependants,	Single,	Joint
            //0	$16,500	$20,580
            //1	$20,400	$24,480
            //2	$24,300	$28,380
            //3	$28,200	$32,280
            //4	$32,100	$36,180
            //5 or more - currently set four dependants plus an additional $3,900 for each further dependant

        return 10000; //placeholder
    }

    public double GetCreditRepayment() //3% of credit limit is the estimated monthly credit card repayment amount
    {
        double creditRepayment = _creditLimit * 0.03;

        return creditRepayment; 
    }

    public void DisplayApplicationDetails()
    {
        if(_isSingle == true)
        {
            Console.WriteLine("> Status: Single");
        }

        else
        {
            Console.WriteLine("> Status: Partnered");
        }

        Console.WriteLine($"> Dependants: {_dependants}");
        Console.WriteLine($"> Annual Net Income: ${_netIncome}");
        Console.WriteLine($"> Estimated Annual Living Costs: ${_annualLivingCosts}");
        Console.WriteLine($"> Total Credit Limit: ${_creditLimit}");

        
    }

}