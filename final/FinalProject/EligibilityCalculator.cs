using System;

public class EligibilityCalculator
{
    private Applicant _applicant;
    private Loan _loan;
    private double _netDisposableIncome;

    private double _ndiRatio;

    private double _totalCommitments;
    private bool _isEligble;

    public EligibilityCalculator(Applicant applicant, Loan loan)
    {
        _applicant = applicant;
        _loan = loan;

        double newLoanRepayment = (_loan.CalculateMonthlyRepayments()) * 12; //annual estimated repayment for the loan application
        double creditRepayment = _applicant.GetCreditRepayment();
        int otherLoanRepayments = _applicant.GetOtherLoans();

        _totalCommitments = newLoanRepayment + creditRepayment + otherLoanRepayments;        

    }

    public void CalculateNetDisposableIncome()
    {
        double netIncome = _applicant.GetNetIncome();
        double livingCosts = _applicant.GetEstimatedLivingCosts();

        
        _netDisposableIncome = netIncome - livingCosts;

    }

    public void CalculateNdiRatio()
    {
        _ndiRatio = _netDisposableIncome / _totalCommitments;

        if(_ndiRatio >= 1)
        {
            _isEligble = true; //NDI must be at least 1:1 to be eligible
        }

        if(_ndiRatio < 1)
        {
            _isEligble = false;
        }

    }

    public double GetNdiRatio()
    {
        return _ndiRatio;
    }

    public bool IsEligble()
    {
        return _isEligble;
    }


}