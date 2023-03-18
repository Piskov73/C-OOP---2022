using MilitaryElite.Core;
using MilitaryElite.IO;
using MilitaryElite.IO.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IRead read=new ConsoleRead();
            IWrite write=new ConsoleWrite();
            Engine engine = new Engine(read,write);
            engine.Run();
        }
    }
}
