
namespace MilitaryElite
{
    using IO;
    using IO.Interface;
    using MilitaryElite.Core;
    using MilitaryElite.Core.Interface;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRead read = new ConsoleRead();
            IWrite write = new ConsoleWrite();
            IEngine engine =new Engine(read, write);
            engine.Run();
        }
    }
}
