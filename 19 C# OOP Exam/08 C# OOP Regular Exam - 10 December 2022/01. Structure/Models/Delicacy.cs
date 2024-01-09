using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models
{
    public abstract class Delicacy : IDelicacy
    {
        private string delicacyName;
        private double price;
        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
            this.Price=price;
        }
        public string Name
        {
            get => delicacyName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }

                delicacyName = value;
            }
        }

        public double Price { get => price; private set => price = value; }

        public override string ToString()
        {
            return $"{Name} - {Price:f2} lv";
        }
    }
}
