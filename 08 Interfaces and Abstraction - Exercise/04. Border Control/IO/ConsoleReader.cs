namespace BorderControl.IO
{
    using System;

    using Interfaces;

    internal class ConsoleReader : IReader
    {
        public string ReadLine()=> Console.ReadLine();
      
    }
}
