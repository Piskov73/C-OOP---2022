using System;
using System.Collections.Generic;

namespace _04PizzaCalories
{
    public class Pizza
    {
        private const int TOPINGS_RANGE = 10;
        private Dough dough;
        private List<Topping> toppings;
        private string name;
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)|| string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_PIZZA_NAME, value));
                }
                name = value;
            }
        }
        public int Count => toppings.Count;
        public void AddDough(Dough dough)
        {
            this.dough = dough;
        }
        public void AddTopping(Topping topping)
        {
            if (TOPINGS_RANGE == Count)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.TOPINGS_RANGE));
            }
            toppings.Add(topping);
        }
        public double GetPizzaCalories => Calories();
        private double Calories()
        {
            double sum = 0;
            if(toppings.Count > 0)
            {
                foreach (var item in toppings)
                {
                    sum += item.GetCaloriesTopping;
                }
            }
            sum += dough.GetCaloriesDough;

            return sum;
        }
        public override string ToString()
        {
            return $"{this.Name} - {GetPizzaCalories:f2} Calories.";
        }

    }
}
