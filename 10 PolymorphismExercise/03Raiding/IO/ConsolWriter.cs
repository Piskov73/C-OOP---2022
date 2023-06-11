namespace Raiding.IO
{
    using System;

    using Interfaces;
    internal class ConsolWriter : IWriter
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
