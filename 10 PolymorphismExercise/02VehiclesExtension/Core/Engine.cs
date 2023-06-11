namespace Vehicles.Core
{
    using System;

    using System.Collections.Generic;
    using Interfaces;
    using IO.Interface;
    using Factory.Intervaces;
    using Models.Interfaces;
    using System.Linq;
    using Vehicles.Messages;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFactoryVehicles factoryVehicles;
        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }
        public Engine(IReader reader, IWriter writer, IFactoryVehicles factoryVehicles)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.factoryVehicles = factoryVehicles;
        }

        public void Run()
        {
            vehicles.Add(GetVehicle());
            vehicles.Add(GetVehicle());
            vehicles.Add(GetVehicle());

            CompleteTask();

            Print();

        }

        private IVehicle GetVehicle()
        {
            string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);
            double tankCapasity = double.Parse(tokens[3]);
            return factoryVehicles.CreateVehicles(type, fuelQuantity, fuelConsumption, tankCapasity);
        }
        private void CompleteTask()
        {
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {

                try
                {
                    string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string comand = tokens[0];
                    string typeVehicle = tokens[1];
                    double valio = double.Parse(tokens[2]);
                    IVehicle vehicle = vehicles.FirstOrDefault(t => t.GetType().Name == typeVehicle);
                    if (vehicle == null)
                    {
                        throw new ArgumentException(string.Format(EcxeptionMessage.INVALID_VEHICLE));
                    }
                    if (comand == "Refuel")
                    {
                        vehicle.Refuel(valio);
                    }
                    else if (comand == "Drive")
                    {
                        writer.WriteLine(vehicle.Drive(valio));
                    }
                    else if (comand== "DriveEmpty")
                    {
                        writer.WriteLine(vehicle.DriveEmpty(valio));
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(EcxeptionMessage.INVALID_COMMAND));
                    }
                }
                catch (ArgumentException are)
                {
                    writer.WriteLine(are.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine($"{ioe.Message}");
                }

                catch (Exception)
                {

                    throw;
                }
            }
        }
        private void Print()
        {
            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
