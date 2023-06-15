namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Hen : Bird
    {
        private const double HEN_MULTIPLICATION = .35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> FavouriteFood =>
            new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double MultiplicationWeight => HEN_MULTIPLICATION;

        public override string Sound()
        {
            return "Cluck";
        }
    }
}
