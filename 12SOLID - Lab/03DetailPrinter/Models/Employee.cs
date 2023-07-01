namespace DetailPrinter.Models
{
    using Interfaces;
    public class Employee : IEemployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public virtual string Print()
        {
            return Name;
        }
    }
}
