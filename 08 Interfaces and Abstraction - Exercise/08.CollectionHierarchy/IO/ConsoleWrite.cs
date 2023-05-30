namespace CollectionHierarchy.IO
{
    using System;
    using Interface;
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
