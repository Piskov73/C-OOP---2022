

namespace Telephony
{
    using System;
    using Telephony.Coor;
    using Telephony.Coor.Interface;
    using Telephony.IO;
    using Telephony.IO.Interface;

    public class StartUp
    {
       
        public static void Main(string[] args)
        {

            IRead read = new ConsolReader();
            IWrite write = new ComsoleWrite();
            IEngine engine = new Engine(read, write);
            engine.Run();
        }

    }
}
