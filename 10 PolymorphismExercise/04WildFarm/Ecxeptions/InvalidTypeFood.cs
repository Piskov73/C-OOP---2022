namespace WildFarm.Ecxeptions
{
    using System;
    public class InvalidTypeFood : Exception
    {
        private const string NOT_FOOD_FOND = "Invalid FOOD!!!";
       
        public InvalidTypeFood() : base()
        {
            
        }
        public InvalidTypeFood(string message) : base(NOT_FOOD_FOND)
        {

        }
    }
}
