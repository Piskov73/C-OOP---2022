using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kittens : Cat
    {
        private const string GENDER = "Female";
        private const string KITTENS_SAUND = "Meow";
           
        public Kittens(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string Gender => GENDER;
        public override string Sound => KITTENS_SAUND;
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
