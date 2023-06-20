namespace MoneyTransactions
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BankAccount
    {
        public BankAccount(int accountNumber, double balanse)
        {
            this.AccountNumber = accountNumber;
            this.Balanse = balanse;
        }
        public int AccountNumber { get; private set; }

        public double Balanse { get; private set; }
        public void Deposit(double sum)
        {
            this.Balanse += sum;
        }
        public void Withdraw(double sum)
        {
            if (this.Balanse - sum < 0)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }
            this.Balanse -= sum;
        }

        public override string ToString()
        {
            return $"Account {AccountNumber} has new balance: {Balanse:f2}";
        }
    }

    public class StartUp
    {

        public static void Main(string[] args)
        {
            HashSet<BankAccount> accounts = GetAccaunts();
            string comand;
            while ((comand = Console.ReadLine()) != "End")
            {
                string[] comandArgument = comand.Split(' ');
                try
                {
                    string action = comandArgument[0];
                    int accauntNumber = int.Parse(comandArgument[1]);
                    double sum = double.Parse(comandArgument[2]);

                    BankAccount account = accounts.FirstOrDefault(n => n.AccountNumber == accauntNumber);
                    if (account == null)
                    {
                        throw new ArgumentException("Invalid account!");
                    }
                    if (action == "Deposit")
                    {
                        account.Deposit(sum);
                    }
                    else if (action == "Withdraw")
                    {
                        account.Withdraw(sum);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }
                    Console.WriteLine(account);
                }
                catch (InvalidOperationException e)
                {

                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
        private static HashSet<BankAccount> GetAccaunts()
        {
            HashSet<BankAccount> accounts = new HashSet<BankAccount>();
            string[] input = Console.ReadLine().Split(',');
            foreach (var item in input)
            {
                string[] arguments = item.Split('-');
                int accauntNumber = int.Parse(arguments[0]);
                double balans = double.Parse(arguments[1]);
                BankAccount account = new BankAccount(accauntNumber, balans);
                accounts.Add(account);
            }
            return accounts;
        }
    }
}
