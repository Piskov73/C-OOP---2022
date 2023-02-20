using System;
using System.Collections.Generic;

namespace _3ShoppingSpree
{
    public class Person
    {

        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<Product>();
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
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(MessageException.CANNOT_BE_NEGATIVE));
                }
                money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts { get { return bagOfProducts.AsReadOnly(); } }


        public string AddProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.Money -= product.Cost;
                this.bagOfProducts.Add(product);
                return $"{this.Name} bought {product.Name}";
            }
            return $"{this.Name} can't afford {product.Name}";
        }
        public override string ToString()
        {
            if (this.bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought ";
            }
            List<string> str = new List<string>();
            foreach (var item in bagOfProducts)
            {
                str.Add(item.Name);
            }
            return $"{this.Name} - {string.Join(", ", str)}";
        }

    }
}
