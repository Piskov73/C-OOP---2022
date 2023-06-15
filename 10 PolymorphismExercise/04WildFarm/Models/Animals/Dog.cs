namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Dog : Mammal
    {
        private const double DOG_MULTIPICATION = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> FavouriteFood => new HashSet<Type>() { typeof(Meat) };

        protected override double MultiplicationWeight => DOG_MULTIPICATION;

        public override string Sound()
        {
            return "Woof!";
        }
    }
}
