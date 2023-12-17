using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;
        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        { 
            Id= id;
            Manufacturer= manufacturer;
            Model=model;
            Price= price;
            OverallPerformance= overallPerformance;
        }
        public int Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidProductId));

                id =value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidManufacturer));
             
                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel));

                model = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice));

                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => overallPerformance;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOverallPerformance));

                overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}." +
                $" Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
        }
    }
}
