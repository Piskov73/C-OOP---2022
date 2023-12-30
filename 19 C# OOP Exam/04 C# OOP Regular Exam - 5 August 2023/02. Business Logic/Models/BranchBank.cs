namespace BankLoan.Models
{
    public class BranchBank : Bank
    {
        private const int CAPACITY = 25;
        public BranchBank(string name) 
            : base(name, CAPACITY)
        {
        }
    }
}
