namespace ShoppingSpree
{
    using System;
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name,decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(MesaggesException.INVALID_NAME);
                name = value;
            }
        }
        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(MesaggesException.INVALID_COST);
                cost = value;
            }
        }
    }
}
