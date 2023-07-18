using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var spy=new Spy();
            Console.WriteLine(spy.CollecktorGetersAndSeters("Stealer.Hacker"));
        }
    }
}
