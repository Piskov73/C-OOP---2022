namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int MIN_NAME_SIMBOL = 1;
        private const int MAX_NAME_SIMBOL = 15;
        private const int MAX_TOPPINGS = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name) : this()
        {
            this.Name = name;
        }
        public string Name

        {
            get => this.name;
            private set
            {
                if (value.Length < MIN_NAME_SIMBOL || value.Length > MAX_NAME_SIMBOL||string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(MessageException
                        .INVALID_PIZZA_NAME, MIN_NAME_SIMBOL, MAX_NAME_SIMBOL));
                }

                this.name = value;
            }
        }
        
        public void AddDough(Dough dough)
        {
            this.dough = dough;
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MAX_TOPPINGS)
                throw new ArgumentException(string.Format(MessageException.INVALID_TOPPING_RANGE, MAX_TOPPINGS));

            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{Name} - {(dough.Calories+toppings.Sum(c=>c.Calories)):F2} Calories.";
        }
    }
}
