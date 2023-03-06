namespace Telephony.IO
{
    using System;

    using Telephony.IO.Interface;

    public class ComsoleWrite : IWrite
    {
        public ComsoleWrite() 
        { 

        }
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
           Console.WriteLine(text);
        }
    }
}
