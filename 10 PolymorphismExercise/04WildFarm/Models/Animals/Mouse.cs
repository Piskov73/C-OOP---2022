namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Mouse : Mammal
    {
        private const double MOUSE_MULTIPLICATION = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        //vegetables and fruits
        public override IReadOnlyCollection<Type> FavouriteFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

        protected override double MultiplicationWeight => MOUSE_MULTIPLICATION;

        public override string Sound()
        {
            return "Squeak";
        }
    }
}
