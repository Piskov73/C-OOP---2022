namespace WildFarm.Ecxeptions
{
    using System;
    public class InvalidTypeAnimal : Exception
    {
        public InvalidTypeAnimal(string message) : base(message)
        {
        }

    }
}
