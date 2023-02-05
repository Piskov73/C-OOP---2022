﻿
namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }
        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > 0 && value < 16)
                {
                    base.Age = value;
                }
            }
        }
    }
}
