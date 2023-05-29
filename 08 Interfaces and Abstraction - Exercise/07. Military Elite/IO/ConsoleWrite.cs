namespace MilitaryElite.IO
{
    using System;

    using MilitaryElite.IO.Interface;
    public class ConsoleWrite : IWrite
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
