namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        private const int CAPACITY = 50;
        public CentralBank(string name)
            : base(name, CAPACITY)
        {
        }
    }
}
