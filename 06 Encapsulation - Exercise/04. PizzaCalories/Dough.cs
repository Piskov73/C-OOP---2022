
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double MIN_GRAMS = 1;
        private const double MAX_GRAMS = 200;

        private Dictionary<string, double> modifieres;
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private Dough()
        {
            this.modifieres = new Dictionary<string, double>()
            {


                ["white"] = 1.5,
                ["wholegrain"] = 1.0,
                ["crispy"] = 0.9,
                ["chewy"] = 1.1,
                ["homemade"] = 1.0,
            };
        }
        public Dough(string flourType, string bakingTechnique, double grams) : this()
        {
            this.Fl0urType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;

        }


        public string Fl0urType
        {
            get => flourType;
            private set
            {
                if (ChekModifieres(value)) throw new ArgumentException(MessageException.INVALID_MODIFIERS);
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (ChekModifieres(value)) throw new ArgumentException(MessageException.INVALID_MODIFIERS);
                bakingTechnique = value;
            }
        }
        public double Grams
        {
            get => grams;
            private set
            {
                if (value < MIN_GRAMS || value > MAX_GRAMS)
                    throw new ArgumentException(string.Format(MessageException.INVALID_GRAMS_RANGE, MIN_GRAMS, MAX_GRAMS));
                grams = value;
            }
        }
         public double Calories => 2 * Grams * modifieres[Fl0urType.ToLower()] * modifieres[BakingTechnique.ToLower()];
        private bool ChekModifieres(string modifiere)
        {
            if (this.modifieres.ContainsKey(modifiere.ToLower())) return false;


            return true;
        }

    }
}
