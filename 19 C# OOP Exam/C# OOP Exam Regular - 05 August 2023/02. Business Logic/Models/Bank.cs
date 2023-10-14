using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;
        public Bank(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BankNameNullOrWhiteSpace));
                }
                name = value;
            }
        }


        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }



        public IReadOnlyCollection<ILoan> Loans => this.loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => this.clients.AsReadOnly();
        public double SumRates()
        {
            return 1.0 * this.Loans.Sum(l => l.InterestRate);
        }
        public void AddClient(IClient Client)
        {
            if (this.Clients.Count == this.Capacity)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }

            this.clients.Add(Client);
        }
        public void RemoveClient(IClient Client)
        {
           this.clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }

        public string GetStatistics()
        {
            string name = "";
            if(this.Clients.Count == 0)
            {
                name = "none";
            }
            else
            {
               List<string> names=this.Clients.Select(c => c.Name).ToList();
                name= string.Join(", ", names);
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}")
                .AppendLine($"Clients: {name}")
                .AppendLine($"Loans: {this.Loans.Count}, Sum of Rates: {SumRates()}");


            return sb.ToString().TrimEnd();
        }

       


    }
}
