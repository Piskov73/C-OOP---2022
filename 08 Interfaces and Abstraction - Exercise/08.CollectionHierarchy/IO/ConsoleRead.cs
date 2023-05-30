
namespace CollectionHierarchy.IO
{
    using System;

    using CollectionHierarchy.IO.Interface;
    public class ConsoleRead : IRead
    {
        public string ReadLine() => Console.ReadLine();


    }
}
