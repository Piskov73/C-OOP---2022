using System;
using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.IO;
using Telephony.IO.Interface;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRead read = new ConsoleRead();
            IWrite write = new ConsoleWrite();

            IEngine engine=new Engine(read, write);
            engine.Run();
        }
    }
}
