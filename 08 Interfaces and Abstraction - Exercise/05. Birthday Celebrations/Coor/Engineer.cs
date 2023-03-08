namespace BirthdayCelebrations.Coor
{
    using System;
    using System.Collections.Generic;

    using Metods.Interfaces;
    using Interface;
    using IO.Interfaces;
    using BirthdayCelebrations.Metods;

    public class Engineer : IEngineer
    {
        private readonly IRead read;
        private readonly IWrite write;
        private List<IBirthday> persons;
        public Engineer(IRead read, IWrite write)
        {
            this.read = read;
            this.write = write;
            persons = new List<IBirthday>();
        }
        public void Run()
        {
            string input = read.ReadLine();
            while (input != "End")
            {
                try
                {
                    string[] token = input.Split(' ');
                    switch (token[0])
                    {
                        case "Citizen":
                            IBirthday citizen = new Citizens(token[1], int.Parse(token[2]), token[3], token[4]);
                            persons.Add(citizen);
                            break;
                        case "Pet":
                           
                            IBirthday pet = new Pet(token[1], token[2]);
                            persons.Add(pet);
                            break;
                        case "Robot":
                           

                            break;
                    }
                }
                catch (Exception e)
                {
                    write.WriteLine(e.ToString());

                }
                input = read.ReadLine();
            }
            input = read.ReadLine();
            List<IBirthday> birthdays = new List<IBirthday>();
            foreach (var item in persons)
            {
                if (item.Birthday.EndsWith(input))
                {
                    birthdays.Add(item);
                }
            }
            try
            {
                foreach (var item in birthdays)
                {
                    write.WriteLine(item.Birthday);
                }
            }
            catch (Exception)
            {

                throw;
            }
              
            
           
        }
    }
}
