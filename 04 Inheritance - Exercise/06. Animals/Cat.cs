using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        //o	Cat: "Meow meow"
        private const string CAT_SAUND = "Meow meow";
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string Sound => CAT_SAUND;
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
