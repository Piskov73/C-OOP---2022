namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const double MIN_GRAMS = 1;
        private const double MAX_GRAMS = 50;

        private Dictionary<string, double> modifiers;
        private string name;
        private double grams;

        private Topping()
        {
            this.modifiers = new Dictionary<string, double>()
            {
                ["meat"] = 1.2,
                ["veggies"] = 0.8,
                ["cheese"] = 1.1,
                ["sauce"] = 0.9
            };
        }
        public Topping(string name, double grams) : this()
        {
            this.Name = name;
            this.Grams = grams;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (ChekTopping(value)) 
                {
                    
                    throw new ArgumentException(string.Format(MessageException.INVALID_TOPPING, value));
                } 
                this.name = value;
            }
        }
        public double Grams
        {
            get => grams;
            private set
            {
                if (value < MIN_GRAMS || value > MAX_GRAMS)
                {
                    string str = char.ToUpper(this.Name[0]) + this.Name.Substring(1);
                    throw new ArgumentException(string.Format(MessageException.INVALID_GRAMS_TOPPING, this.Name, MIN_GRAMS, MAX_GRAMS));
                }
                    
                grams = value;
            }
        }
        public double Calories => 2 * this.Grams * this.modifiers[Name.ToLower()];
        private bool ChekTopping(string nameTopping)
        {
            if (modifiers.ContainsKey(nameTopping.ToLower())) return false;
            return true;
        }
    }
}
