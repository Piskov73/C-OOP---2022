namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using IO.Interfaces;
    using Ecxeptions;
    using Models.Interfaces;
    using Factory.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICreateAnimal createAnimal;
        private readonly ICreateFood createFood;

        private readonly ICollection<IAnimal> animals;
        private Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }
        public Engine(IReader reader, IWriter writer,ICreateAnimal createAnimal, ICreateFood createFood)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.createAnimal = createAnimal;
            this.createFood = createFood;

        }

        public void Run()
        {
            CompleteTask();

            PrintOutput();
        }
        private void CompleteTask()
        {
            string comand;
            while ((comand = reader.ReadLine()) != "End")
            {
                try
                {
                    IAnimal animal = createAnimal.GetAnima(comand);
                    writer.WriteLine(animal.Sound());

                    animals.Add(animal);
                    string[] argumentFood = reader.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string typeFood = argumentFood[0];
                    int quantity = int.Parse(argumentFood[1]);

                    IFood food = createFood.GetFood(typeFood, quantity);
                    animal.Eating(food);


                }
                catch (NotEatnFoodEcxeption nefe)
                {
                    writer.WriteLine(nefe.Message);
                }
                catch (InvalidTypeAnimal ita)
                {
                    writer.WriteLine(ita.Message);
                }
                catch (InvalidTypeFood itf)
                {
                    writer.WriteLine(itf.Message);
                }
            }
        }
        private void PrintOutput()
        {
            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
