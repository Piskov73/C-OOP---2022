namespace StreamProgress.IO
{
    using System;

    using StreamProgress.IO.Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}
