namespace Telephony.IO
{
    using System;

    using Interface;
    public class ConsoleRead : IRead
    {
        public string ReadLine() => Console.ReadLine();

    }
}
