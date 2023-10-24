﻿namespace BankLoan.Models
{
    using Contracts;
    public abstract class Loan : ILoan
    {
        private int interestRate;
        private double amount;
        public Loan(int interestRate, double amount)
        {
            this.InterestRate = interestRate;
            this.Amount = amount;
        }

        public int InterestRate { get => interestRate; private set => interestRate = value; }

        public double Amount { get => amount; private set => amount = value; }
    }
}