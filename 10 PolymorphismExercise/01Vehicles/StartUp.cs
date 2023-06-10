namespace Vehicles
{
    using Core;
    using Core.Interfaces;
    using Vehicles.IO;
    using IO.Interface;
    using Vehicles.Factory.Intervaces;
    using Vehicles.Factory;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsolReader();
            IWriter writer=new ConsoleWriter();
            IFactoryVehicles factory = new FactoryVehicles();
            IEngine engine = new Engine(reader,writer,factory);

            engine.Run();
        }
    }
}
