using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stak = new StackOfStrings();
            string[] strings= new string[] {"1", "2","3","4"};

            Console.WriteLine(stak.IsEmpty());
            stak.AddRange(strings);
            Console.WriteLine(stak.IsEmpty());
            Console.WriteLine(string.Join(", ",stak));
        }
    }
}
