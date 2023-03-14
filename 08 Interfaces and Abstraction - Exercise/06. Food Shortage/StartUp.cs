namespace FoodShortage
{
    using _06FoodShortage.Core;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IRead read=new ConsoleRead();
            IWrire wrire= new ConsoleWrite();
            var engine = new Engine(read,wrire);
            engine.Run();
        }
    }
}
