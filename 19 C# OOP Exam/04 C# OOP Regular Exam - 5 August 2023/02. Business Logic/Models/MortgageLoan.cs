namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int INTERES_RATE = 3;
        private const double AMOUNT = 50000;
        public MortgageLoan()
            : base(INTERES_RATE, AMOUNT)
        {
        }
    }
}
