

namespace Telephony.IO
{
    using System;

    using Telephony.IO.Interface;
    public class ConsolReader : IRead
    {
        public ConsolReader()
        {

        }
        public string ReadLain()=>Console.ReadLine();
     
    }
}
