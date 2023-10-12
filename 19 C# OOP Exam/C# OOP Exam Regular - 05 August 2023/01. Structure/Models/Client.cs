using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        private string name;
        private string id;
        private int interest;
        private double income;


        public Client(string name, string id, int interest, double income)
        {
            this.Name = name;
            this.Id = id;
            this.Interest = interest;
            this.Income = income;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientNameNullOrWhitespace));
                }
                name = value;
            }
        }


        public string Id
        {
            get { return id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientIdNullOrWhitespace));
                }
                id = value;
            }
        }

        public int Interest
        {
            get { return interest; }
            protected set { interest = value; }
        }

        public double Income
        {
            get { return income; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientIncomeBelowZero));
                }
                income = value;
            }
        }



        public virtual void IncreaseInterest()
        {

        }

    }
}
