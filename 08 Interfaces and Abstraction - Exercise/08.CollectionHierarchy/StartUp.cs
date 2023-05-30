
namespace CollectionHierarchy
{
    using Core;
    using Core.Interface;
    using IO;
    using IO.Interface;
    public class StartUp
    {
      public  static void Main(string[] args)
        {
            IRead read = new ConsoleRead();
            IWrite write = new ConsoleWrite();
            IEngine engine = new Engine(read, write);
            engine.Run();

        }
    }
}
