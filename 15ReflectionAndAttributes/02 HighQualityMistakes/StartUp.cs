namespace Stealer
{
using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string output = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(output);

        }
    }
}
