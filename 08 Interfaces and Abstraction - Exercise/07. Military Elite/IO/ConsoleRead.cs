namespace MilitaryElite.IO
{
    using System;

    using MilitaryElite.IO.Interfaces;

    public class ConsoleRead : IRead
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
