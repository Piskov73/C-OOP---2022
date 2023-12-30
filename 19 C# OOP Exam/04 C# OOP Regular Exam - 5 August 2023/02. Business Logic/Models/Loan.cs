using BankLoan.Models.Contracts;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        private int interestRate;
        private double amount;
        public Loan(int interestRate, double amount)
        {
            this.interestRate = interestRate;
            this.amount = amount;
        }
        public int InterestRate => this.interestRate;

        public double Amount => this.amount;
    }
}
