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
            Name = name;
            this.capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.BankNameNullOrWhiteSpace));
                name = value;
            }
        }
     

        public int Capacity => this.capacity;

        public IReadOnlyCollection<ILoan> Loans => this.loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => this.clients.AsReadOnly();
        public double SumRates()
        {
            return (double)this.loans.Sum(l => l.InterestRate);
        }

        public void AddClient(IClient Client)
        {
            if (this.clients.Count == Capacity)
                throw new ArgumentException(string.Format(ExceptionMessages.NotEnoughCapacity));

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
            string clientName = "none";
            if(this.clients.Count > 0)
            {
                var clientsNames=Clients.Select(n=>n.Name).ToList();
                clientName = string.Join(", ", clientsNames);
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}")
                .AppendLine($"Clients: {clientName}")
                .AppendLine($"Loans: {Loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().TrimEnd();
        }


    }
}
