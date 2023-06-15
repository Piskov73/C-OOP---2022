namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Owl : Bird
    {
        private const double OWL_MULTIPLICATION = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> FavouriteFood => new HashSet<Type>() {typeof(Meat) };

        protected override double MultiplicationWeight => OWL_MULTIPLICATION;

        public override string Sound()
        {
            return "Hoot Hoot";
        }
    }
}
