namespace Bakery.Models.Drinks
{
    using System;

    using Utilities.Messages;
    using Contracts;
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;
        public Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName));

                name = value;
            }
        }

        public int Portion
        {
            get => portion;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPortion));

                portion = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice));

                price = value;
            }
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBrand));
                brand = value;
            }
        }
        public override string ToString()
        {
            return $"{Name} {Brand} - {Portion}ml - {Price:f2}lv";
        }
    }
}
