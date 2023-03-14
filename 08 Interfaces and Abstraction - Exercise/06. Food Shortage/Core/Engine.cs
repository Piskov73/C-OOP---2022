namespace _06FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Interfaces;
    using FoodShortage.IO.Interfaces;

    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrire wrire;
        List<IBuyer> residents = new List<IBuyer>();
        public Engine(IRead read,IWrire wrire)
        {
            this.read = read;
            this.wrire = wrire;
        }
        public void Run()
        {

            int numbLine = int.Parse(read.Read());
            for (int i = 0; i < numbLine; i++)
            {
                string[] input = read.Read().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 3)
                {
                    IBuyer reble = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    residents.Add(reble);
                }
                else if (input.Length == 4)
                {
                    IBuyer citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    residents.Add(citizen);
                }
            }
            string name = read.Read();
            while (name != "End")
            {
                var filterName = residents.FirstOrDefault(x => x.Name == name);
                if (filterName != null)
                {
                    filterName.BuyFood();
                }
                name = read.Read();
            }
            wrire.WriteLine(residents.Sum(x => x.Food).ToString());
        }
    }
}
