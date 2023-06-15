namespace WildFarm.Factory
{
    using System;
    using Interfaces;
    using Models.Interfaces;
    using WildFarm.Ecxeptions;
    using WildFarm.Models.Animals;

    public class CreateAnimal : ICreateAnimal
    {
        public CreateAnimal()
        {

        }
        public IAnimal GetAnima(string text)
        {
            IAnimal animal;
            string[] arguments = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //{Type} {Name} {Weight} 
            string type = arguments[0];
            string name = arguments[1];
            double weight = double.Parse(arguments[2]);
            // •Hen - 0.35
            if (type == "Hen")
            {
                double wingSize = double.Parse(arguments[3]);
                animal = new Hen(name, weight, wingSize);
            }
            //•	Owl - 0.25
            else if (type == "Owl")
            {
                double wingSize = double.Parse(arguments[3]);
                animal = new Owl(name, weight, wingSize);
            }
            //•	Mouse - 0.10
            else if (type == "Mouse")
            {
                string livingRegion = arguments[3];
                animal = new Mouse(name,weight,livingRegion);
            }
            //•	Dog - 0.40
            else if (type == "Dog")
            {
                string livingRegion = arguments[3];
                animal = new Dog(name, weight, livingRegion);
            }
            //•	Cat - 0.30
            else if (type == "Cat")
            {
                string livingRegion = arguments[3];
                string breed = arguments[4];
                animal = new Cat(name,weight,livingRegion,breed);
            }
            //•	Tiger - 1.00
            else if (type == "Tiger")
            {
                string livingRegion = arguments[3];
                string breed = arguments[4];
                animal=new Tiger(name,weight,livingRegion,breed);
            }
            else
            {
                throw new NotEatnFoodEcxeption("Invalid ANIMAL!!!");
            }


            return animal;
        }
    }
}
