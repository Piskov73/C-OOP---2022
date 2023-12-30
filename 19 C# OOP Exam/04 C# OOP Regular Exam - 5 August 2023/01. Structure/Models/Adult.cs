namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int INTEREST = 4;
        public Adult(string name, string id, double income)
            : base(name, id, INTEREST, income)
        {
        }

        public override void IncreaseInterest()
        {
            base.Interest += 2;
        }
    }
}
