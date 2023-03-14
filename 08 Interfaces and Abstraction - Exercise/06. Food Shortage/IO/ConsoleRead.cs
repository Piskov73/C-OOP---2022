namespace FoodShortage.IO
{
    using System;

    using Interfaces;
    public class ConsoleRead : IRead
    {
        public string Read() =>Console.ReadLine();
    }
}
