namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int INTEREST= 2;
        public Student(string name, string id,  double income) 
            : base(name, id, INTEREST, income)
        {
        }

        public override void IncreaseInterest()
        {
            base.Interest += 1;
        }
    }
}
