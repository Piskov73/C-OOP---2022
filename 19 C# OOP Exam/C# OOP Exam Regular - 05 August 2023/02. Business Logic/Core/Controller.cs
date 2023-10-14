using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace BankLoan.Core
{
    public class Controller : IController
    {
       

        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {

            this.loans = new LoanRepository();
            this.banks = new BankRepository();

        }

        public string AddBank(string bankTypeName, string name)
        {

            IBank bank;
            if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }
            else if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.BankTypeInvalid));

            }

            this.banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bank.GetType().Name);

        }
        public string AddLoan(string loanTypeName)
        {
            ILoan loan;

            if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.LoanTypeInvalid));
            }

            this.loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = this.loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            var bank = this.banks.FirstModel(bankName);
            bank.AddLoan(loan);

            this.loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client;
            if (clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }
            else if (clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ClientTypeInvalid));
            }
            var bank = this.banks.FirstModel(bankName);
            if (bank.GetType().Name == nameof(CentralBank) && clientTypeName != nameof(Adult) ||
                bank.GetType().Name == nameof(BranchBank) && clientTypeName != nameof(Student))
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            bank.AddClient(client);

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }


        public string FinalCalculation(string bankName)
        {
            var bank = this.banks.FirstModel(bankName);

            var sumClient = bank.Clients.Sum(x => x.Income);
            var sulLoan = bank.Loans.Sum(x => x.Amount);
            var funds = (sumClient + sulLoan).ToString("0.00");
            return string.Format(OutputMessages.BankFundsCalculated,bankName,funds);
        }


        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.banks.Models)
            {
                sb.AppendLine(item.GetStatistics());
            }


            return sb.ToString().TrimEnd();
        }
    }
}
