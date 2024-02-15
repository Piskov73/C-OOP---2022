using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int numberOfPeople;
        private bool isReserved;
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople = 0;
            this.isReserved = false;
        }
        public int TableNumber { get => tableNumber; private set => tableNumber = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTableCapacity));
                capacity = value;
            }
        }

        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set
            {
                pricePerPerson = value;
            }
        }
        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfPeople));
                numberOfPeople = value;
            }
        }

        public bool IsReserved => isReserved;

        public decimal Price => this.drinkOrders.Sum(x => x.Price) + this.foodOrders.Sum(x => x.Price);
        public void Reserve(int numberOfPeople)
        {
            this.isReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }
        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }
        public decimal GetBill()
        {
            return Price;
        }

        public void Clear()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.isReserved = false;
            this.numberOfPeople = 0;
        }


        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }



    }
}
