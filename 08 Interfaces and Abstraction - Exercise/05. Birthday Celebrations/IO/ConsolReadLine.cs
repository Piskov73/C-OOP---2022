namespace BirthdayCelebrations.IO
{
    using System;

    using Interfaces;
    public class ConsolReadLine : IRead
    {
        public string ReadLine() => Console.ReadLine();

    }
}
