namespace Vehicles.IO
{
using System;

using Interface;
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
       
    }
}
