namespace BirthdayCelebrations.IO
{
    using System;

    using BirthdayCelebrations.IO.Interface;
    public class ConsoleRead : IRead
    {
        public string ReadLine()=>Console.ReadLine();

    }
}
