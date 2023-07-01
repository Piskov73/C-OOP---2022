namespace DetailPrinter.Core
{
    using System.Collections.Generic;

    using IO.Interfaces;
    using Models.Interfaces;
    using Interfacws;
    using DetailPrinter.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IList<IEemployee> employees;  
        private Engine()
        {
            this.employees = new List<IEemployee>();
        }
        public Engine(IReader reader,IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            IEemployee employee;
            employee = new Employee("Ivan");
            this.employees.Add(employee);
            employee = new Manager("Petarcho", new List<string>() { "A document 1", "A document 2", "A document 3" });
            this.employees.Add(employee);
            var print = new DetailsPrinter(employees);
           writer.WriteLine(print.PrintDetails());
        }
    }
}
