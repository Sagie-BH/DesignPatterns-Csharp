using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan
{
     class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class BankLoanAcount
    {
        private long _loanAccountNumber;
        private string _userName;
        private string _password;
        bool _loanStatus;
        bool _isLoanInsured;
        double _loanAmount;
        float _interestRate;

        public BankLoanAcount(long loanAccountNumber, string userName, string password,
                                bool loanStatus, bool isLoanInsured, double loanAmount, float interestRate)
        {
            _loanAccountNumber = loanAccountNumber;
            _userName = userName;
            _password = password;
            _loanStatus = loanStatus;
            _isLoanInsured = isLoanInsured;
            _loanAmount = loanAmount;
            _interestRate = interestRate;
        }
        public BankLoanAcount(bool isLoanInsured, double loanAmount, float interestRate)
        {
            _isLoanInsured = isLoanInsured;
            _loanAmount = loanAmount;
            _interestRate = interestRate;
        }
        public BankLoanAcount(long loanAccountNumber, string userName, string password)
        {
            _loanAccountNumber = loanAccountNumber;
            _userName = userName;
            _password = password;
        }
        public BankLoanAcount(double loanAmount, float interestRate)
        {
            _loanAmount = loanAmount;
            _interestRate = interestRate;
        }
    }
    public class LoanInsuranceProcessor
    {
        public void ProcessInsurance()
        {   
            // What if we want to create with some of the arguments 
            //BankLoanAcount bankLoanAcount = new BankLoanAcount()
        }
    }
}
