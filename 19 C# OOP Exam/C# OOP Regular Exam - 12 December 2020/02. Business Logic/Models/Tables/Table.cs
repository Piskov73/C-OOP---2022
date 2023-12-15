using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public class Table : ITable
    {
        private  List<IBakedFood> foodOrders;
        private  List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public int TableNumber { get => tableNumber; private set => tableNumber = value; }


        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTableCapacity));

                capacity = value;
            }
        }


        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfPeople));
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => pricePerPerson; private set => pricePerPerson = value; }

        public bool IsReserved { get=>isReserved; private set=>isReserved=value; }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
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
            return this.foodOrders.Sum(s=>s.Price)+this.drinkOrders.Sum(s=>s.Price);
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved=false;
            this.numberOfPeople = 0;
        }


        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: { Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }



    }
}
