using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models
{
    public abstract class Cocktail : ICocktail
    {
        private string cocktailName;
        private string size;
        private double price;

        public Cocktail(string cocktailName, string size, double price) 
        { 
            this.Name=cocktailName;
            this.Size=size;
            this.Price=price;
        }
        public string Name
        {
            get => cocktailName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                cocktailName = value;
            }
        }

        public string Size { get => size; private set => size = value; }

        public double Price
        {
            get => price;
            private set
            {
                if(this.Size== "Middle")
                {
                    value = value / 3 * 2;
                }
                else if(this.Size== "Small")
                {
                    value = value / 3;
                }
                price=value;
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
