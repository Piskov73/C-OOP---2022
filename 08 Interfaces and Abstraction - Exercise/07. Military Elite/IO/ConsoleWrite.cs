namespace MilitaryElite.IO
{
    using System;

    using MilitaryElite.IO.Interfaces;
    public class ConsoleWrite : IWrite
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
