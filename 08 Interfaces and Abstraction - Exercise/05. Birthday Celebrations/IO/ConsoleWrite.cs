namespace BirthdayCelebrations.IO
{
    using System;


    using BirthdayCelebrations.IO.Interfaces;
    internal class ConsoleWrite : IWrite
    {

        public void Write(object text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
