namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Cat : Feline
    {
        private const double CAT_MULTIPLICATION = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override IReadOnlyCollection<Type> FavouriteFood => new HashSet<Type>() { typeof(Vegetable),typeof(Meat)};

        protected override double MultiplicationWeight => CAT_MULTIPLICATION;

        public override string Sound()
        {
            return "Meow";
        }
    }
}
