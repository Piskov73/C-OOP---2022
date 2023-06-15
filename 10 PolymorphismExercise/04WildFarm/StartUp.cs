namespace WildFarm
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
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICreateAnimal createAnimal = new CreateAnimal();
            ICreateFood createFood = new CreateFood();
            IEngine engine = new Engine(reader, writer, createAnimal, createFood);
            engine.Run();
        }
    }
}
