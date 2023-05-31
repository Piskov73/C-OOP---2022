namespace ExplicitInterfaces.Core
{
    using System;

    using Models;
    using Models.Interface;
    using Interface;
    using IO.Interface;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;
        public Engine(IRead read,IWrite write)
        {
            this.read = read;
            this.write = write;
        }
        public void Run()
        {
            StringBuilder sb = new StringBuilder();
            string input;
            while ((input= read.ReadLine())!="End")
            {
                string[] informationPerson = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = informationPerson[0];
                string country= informationPerson[1];
                int age = int.Parse(informationPerson[2]);

                IPerson person=new Citizen(name, country, age);
                IResident resident=new Citizen(name,country, age);

                sb.AppendLine(person.GetName())
                    .AppendLine(resident.GetName());
            }
            write.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
