using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;
        public Delicacy(string delicacyName, double price)
        {
            this.Name = name;
            this.Price = price;

        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new AggregateException(string.Format(ExceptionMessages.NameNullOrWhitespace));

                name = value;
            }
        }


        public double Price { get => this.price; private set => this.price = value; }

        public override string ToString()
        {
            return $"{Name} - {Price:F2} lv";
        }
    }
}
