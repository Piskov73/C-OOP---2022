namespace Vehicles
{
    using Core;
    using Core.Interfaces;
    using IO;
    using IO.Interface;
    using Factories;
    using Factories.Interface;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehiclesFactories vehiclesFactories = new VehiclesFacktorie();
            IEngine engine = new Engine(reader, writer, vehiclesFactories);
            engine.Run();
        }
    }
}
