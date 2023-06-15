namespace WildFarm.Ecxeptions
{
    using System;

    public class NotEatnFoodEcxeption : Exception
    {
        public NotEatnFoodEcxeption(string message) : base(message)
        {

        }
    }
}
