using System;
using System.Collections.Generic;
using System.Linq;

namespace _04PizzaCalories
{
    public class Topping
    {
        private const int MIN_GRAMS = 0;
        private const int MAX_GRAMS = 50;
        private Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            ["Meat"] = 1.2,
            ["Veggies"] = 0.8,
            ["Cheese"] = 1.1,
            ["Sauce"] = 0.9
        };
        private string topping;
        private int gram;
        public Topping(string topping, int gram)
        {
            if (ChekTopping(toppings, topping))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TYPE_TOPPING,topping));
            }
            var filter=toppings.First(x=>x.Key.ToLower()==topping.ToLower());
            this.Toppimg = filter.Key;
            this.Gram = gram;
        }
        public string Toppimg
        {
            get { return topping; }
            private set
            {
              
                
                topping = value;
            }
        }
        public int Gram
        {
            get { return gram; }
            private set
            {
                if(value< MIN_GRAMS || value > MAX_GRAMS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_RANGE_TOPPING,this.Toppimg));
                }
                gram = value;
            }
        }
        public double GetCaloriesTopping => 2 * this.Gram * toppings[this.Toppimg];
        private bool ChekTopping(Dictionary<string, double> toppings, string value)
        {
            foreach (var item in toppings)
            {
                if (item.Key.ToLower() == value.ToLower())
                {
                    return false;
                }
            }
            return true;
        }

    }
}
