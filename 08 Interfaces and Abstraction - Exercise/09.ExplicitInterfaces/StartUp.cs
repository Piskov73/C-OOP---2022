namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Core;
    using ExplicitInterfaces.Core.Interface;
    using IO;
    using IO.Interface;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRead read = new ConsoleRead();
            IWrite write = new ConsoleWrite();
            IEngine engine=new Engine(read,write);
            engine.Run();
        }
    }
}
