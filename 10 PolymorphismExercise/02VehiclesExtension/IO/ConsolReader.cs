namespace Vehicles.IO
{
    using System;
    using Interface;
    public class ConsolReader : IReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}
