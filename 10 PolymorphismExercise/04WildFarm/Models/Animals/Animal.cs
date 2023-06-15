namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Ecxeptions;

    public abstract class Animal : IAnimal
    {
        private Animal()
        {
            this.FoodEaten = 0;
        }
        protected Animal(string name, double weight) : this()
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double MultiplicationWeight { get; }
        public abstract IReadOnlyCollection<Type> FavouriteFood { get; }

        public void Eating(IFood food)
        {
            if (!this.FavouriteFood.Any(gt => gt.Name == food.GetType().Name))
            {
                throw new NotEatnFoodEcxeption(string.Format
                    (ExeptionMessages.ANIMAL_NOT_EAT, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += this.MultiplicationWeight * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public abstract string Sound();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
