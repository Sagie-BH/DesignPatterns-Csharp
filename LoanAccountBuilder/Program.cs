using System;

namespace LoanAccountBuilder
{
    // Not good example
    class Program
    {
        static void Main(string[] args)
        {
            var laonAccount = new BankAccountBuilder()
                    .WithAccountNumber(123)
                    .WithCredential("james", "bond")
                    .WithInterest(5.5)
                    .WithLoanAmount(40000)
                    .Build();
        }
    }
    // Fluent builder is a variation of Builder design pattern where every method except Build returns this pointer.
    public class BankAccountBuilder
    {
        private long _accountNumber;
        private string _userName;
        private string _password;
        double _loanAmount;
        double _interestRate;

        public BankAccountBuilder WithAccountNumber(int accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }
        private bool CanBuild()
        {
            return _accountNumber > 0;
        }
        public BankAccountBuilder WithCredential(string userName, string password)
        {
            _userName = userName;
            _password = password;
            return this;
        }
        public BankAccountBuilder WithInterest(double interestRate)
        {
            _interestRate = interestRate;
            return this;
        }
        public BankAccountBuilder WithLoanAmount(double loanAmount)
        {
            _loanAmount = loanAmount;
            return this;
        }
        public BankAccountBuilder Build()
        {
            return CanBuild()  ? this : throw new Exception("Cannot build a valid object");
        }
    }

}
