using System;

namespace _3ShoppingSpree
{
    public class Product
    {
       
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;

        }



        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(MessageException.CANNOT_BE_EMPTY));
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(MessageException.CANNOT_BE_NEGATIVE));
                }
                cost = value;
            }
        }

    }
}
