namespace MilitaryElite.IO
{
    using System;

    using Interface;
    public class ConsoleRead : IRead

    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
