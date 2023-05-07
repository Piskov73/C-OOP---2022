namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        private Person()
        {
            this.products = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(MesaggesException.INVALID_NAME);
                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(MesaggesException.INVALID_COST);
                this.money = value;
            }
        }
        public string BuyProduct(Product product)
        {
            if (product.Cost > this.money)
            {
                return $"{this.Name} can't afford {product.Name}";
            }
            products.Add(product);
            this.money -= product.Cost;
            return $"{this.Name} bought {product.Name}";
        }
        public override string ToString()
        {
            if (this.products.Count == 0) return $"{this.Name} - Nothing bought";
            var listProductName = new List<string>();
            foreach (var item in this.products)
            {
                listProductName.Add(item.Name);
            }

            return $"{this.Name} - {string.Join(", ", listProductName)}";
        }
    }
}
