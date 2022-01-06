using System;

namespace LoanAccountBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new BankAccountBuilder();
            BuildNewFreshAccount(builder);

            Console.WriteLine(builder.Build().ToString());
        }
        public static void BuildNewFreshAccount(IBankAccountBuilder builder)
        {
            builder.WithAccountNumber(123)
                    .WithCredential("sagie", "12345");
        }
    }
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }

        public override string ToString()
        {
            return $"Account number: {AccountNumber}\n User name: {UserName}\tPassword: {Password}\nLoan amount = {LoanAmount}\t  Interest: {InterestRate}";
        }
    }
    public interface IBankAccountBuilder
    {
        IBankAccountBuilder WithAccountNumber(int accountNumber);
        IBankAccountBuilder WithCredential(string userName, string password);
        IBankAccountBuilder WithInterest(double interestRate);
        IBankAccountBuilder WithLoanAmount(double loanAmount);
    }
    public class BankAccountBuilder : IBankAccountBuilder
    {
        private BankAccount _bankAccount = new BankAccount();
        public IBankAccountBuilder WithAccountNumber(int accountNumber)
        {
            _bankAccount.AccountNumber = accountNumber;
            return this;
        }
        private bool CanBuild()
        {
            return _bankAccount.AccountNumber > 0;
        }
        public IBankAccountBuilder WithCredential(string userName, string password)
        {
            _bankAccount.UserName = userName;
            _bankAccount.Password = password;
            return this;
        }
        public IBankAccountBuilder WithInterest(double interestRate)
        {
            _bankAccount.InterestRate = interestRate;
            return this;
        }
        public IBankAccountBuilder WithLoanAmount(double loanAmount)
        {
            _bankAccount.LoanAmount = loanAmount;
            return this;
        }
        public BankAccount Build()
        {
            return CanBuild() ? _bankAccount : throw new Exception("Cannot build a valid object");
        }
    }

}
