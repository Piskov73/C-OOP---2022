namespace Stealer
{
using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string ourput = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(ourput);
        }
    }
}
