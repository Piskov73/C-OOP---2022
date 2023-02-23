using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _04PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> typeFlours = new Dictionary<string, double>()
        {
            ["White"] = 1.5,
            ["Wholegrain"] = 1.0
        };
        private Dictionary<string, double> typeBakings = new Dictionary<string, double>()
        {
            ["Crispy"] = 0.9,
            ["Chewy"] = 1.1,
            ["Homemade"] = 1.0
        };
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 200;
        private string flour;
        private string baking;
        private int grams;
        public Dough(string typeFlour, string typeBaking, int grams)
        {
            if (ChekDough(typeFlours, typeFlour))
            {
                 throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TYPE_DOUGH));

            }
            var filterFlour = GetFilter(typeFlours, typeFlour);
            this.Flour = filterFlour.Key;

            if(ChekDough(typeBakings, typeBaking))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TYPE_DOUGH));
            }
            var filerBaking=GetFilter(typeBakings, typeBaking);
            this.Baking = filerBaking.Key;
            this.Grams = grams;
        }
        public string Flour
        {
            get { return flour; }
            private set
            {
                
                
                flour = value;
            }
        }
        public string Baking
        {
            get { return baking; }
            private set
            {
                
                
                baking = value;
            }
        }
        public int Grams
        {
            get { return grams; }
            private set
            {
                if(value< MIN_GRAMS || value > MAX_GRAMS)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_RANGE_DOUGH);
                }
                grams = value;
            }
        }
        public double GetCaloriesDough => 2 * this.Grams * this.typeFlours[this.Flour] * typeBakings[this.Baking];
        private bool ChekDough(Dictionary<string, double> type, string name)
        {
            foreach (var item in type)
            {
                if (item.Key.ToLower() == name.ToLower())
                {
                    return false;
                }
            }
            return true;
        }
        private KeyValuePair<string,double> GetFilter(Dictionary<string,double> map,string item)
        {
            return map.FirstOrDefault(x=>x.Key.ToLower()==item.ToLower());
        }



    }
}
