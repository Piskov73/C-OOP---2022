namespace Bakery.Models.BakedFoods
{
    using System;

    using Utilities.Messages;
    using Contracts;
 

    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal pricestrin;
        public BakedFood(string name, int portion, decimal pricestrin)
        {
            this.Name=name;
            this.Portion=portion;
            this.Price=pricestrin;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    

                name = value;
            }
        }

        public int Portion
        {
            get => portion;
            private set
            {
                if(value<=0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPortion));

                portion = value;
            }
        }

        public decimal Price
        {
            get => pricestrin;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice));
                pricestrin = value;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:f2}";
        }
    }
}
