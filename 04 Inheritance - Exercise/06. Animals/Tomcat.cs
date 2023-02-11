using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string GENDER = "Male";
        private const string TOMCAT_SAUND = "MEOW";

        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string Gender => GENDER;
        public override string Sound => TOMCAT_SAUND;
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
