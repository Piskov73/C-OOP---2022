namespace FoodShortage.IO
{
    using System;

    using Interfaces;
    internal class ConsoleWrite : IWrire
    {
        public void Write(string text)
        {
          Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
