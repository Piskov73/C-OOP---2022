namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Tiger : Feline
    {
        private const double TIGER_MULTIPLICATION = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> FavouriteFood => new HashSet<Type>() { typeof(Meat)};

        protected override double MultiplicationWeight => TIGER_MULTIPLICATION;

        public override string Sound()
        {
            return "ROAR!!!";
        }
    }
}
