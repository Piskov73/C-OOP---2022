namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;

    using BirthdayCelebrations.Models;
    using Interface;
    using IO.Interface;
    using Models.Interface;
    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;
        private readonly HashSet<IBirthdate> birthdays;
        public Engine(IRead read, IWrite write)
        {
            this.read = read;
            this.write = write;
            birthdays = new HashSet<IBirthdate>();
        }
        public void Run()
        {
            string input = read.ReadLine();
            while (input != "End")
            {
                string[] personInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string person= personInfo[0];
                string name= personInfo[1];
                if (person == "Citizen")
                {
                    //"Citizen <name> <age> <id> <birthdate>" 
                    int age = int.Parse(personInfo[2]);
                    string id = personInfo[3];
                    string birthdate = personInfo[4];
                    IBirthdate citizen=new Citizen(name,age,id,birthdate);
                    birthdays.Add(citizen);
                }
                else if (person == "Pet")
                {
                    string birthdate = personInfo[2];
                    IBirthdate pet = new Pet(name, birthdate);
                    birthdays.Add(pet);
                }

                input = read.ReadLine();
            }
            input = read.ReadLine();
            foreach (var item in birthdays)
            {
                if (item.Birthdate.EndsWith(input))
                {
                    write.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
