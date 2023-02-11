using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Dog : Animal
    {
        //o	Dog: "Woof!"
        private const string SOUND_DOG = "Woof!";
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {

        }
        public override string Sound => SOUND_DOG;
        public override string ToString()
        {
          return base.ToString();
        }
    }
}
