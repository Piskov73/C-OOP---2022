namespace Raiding
{
    using Core;
    using Core.Interfaces;
    using Factory;
    using Factory.Interfaces;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsolReader();
            IWriter writer = new ConsolWriter();
            ICreateHeroFactory factory = new CreateHeroFactory();

            IEngine engine = new Engine(reader,writer,factory);
            engine.Run();
        }
    }
}
