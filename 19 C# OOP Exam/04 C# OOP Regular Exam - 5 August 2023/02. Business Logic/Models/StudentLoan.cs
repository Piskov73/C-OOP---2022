namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int INTERES_RATE = 1;
        private const double AMOUNT = 10000;
        public StudentLoan()
            : base(INTERES_RATE, AMOUNT)
        {
        }
    }
}
