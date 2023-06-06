namespace Vehicles.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using Factories.Interface;
    using IO.Interface;
    using Models.Interface;
    using Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehiclesFactories vehiclesFactories;

        private readonly ICollection<IVehicle> vehicles;
        protected Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }
        public Engine(IReader reader, IWriter writer, IVehiclesFactories vehiclesFactories)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehiclesFactories = vehiclesFactories;
        }

        public void Run()
        {
            this.vehicles.Add(CreateVehicleUsingFactory());
            this.vehicles.Add(CreateVehicleUsingFactory());

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    this.Comand();
                }
                catch (ExceptionInvalidVehicle eiv)
                {
                    writer.WriteLine(eiv.Message);
                }
                catch (ExeptionNeedsRefueling enr)
                {
                    writer.WriteLine(enr.Message);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            this.Print();
        }
        private IVehicle CreateVehicleUsingFactory()
        {
            string[] comand = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = comand[0];
            double fuelQuantity = double.Parse(comand[1]);
            double fuelConsumption = double.Parse(comand[2]);
            IVehicle vehicle = this.vehiclesFactories.CreateVehicle(type, fuelQuantity, fuelConsumption);
            return vehicle;

        }
        private void Comand()
        {

            string[] command = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string action = command[0];
            string type = command[1];
            double argument = double.Parse(command[2]);
            IVehicle currentVehicle = this.vehicles.FirstOrDefault(v => v.GetType().Name == type);
            if (currentVehicle == null)
            {
                throw new ExceptionInvalidVehicle("The vehicle cannot be found!");
            }
            if (action == "Drive")
            {
                writer.WriteLine(currentVehicle.Drive(argument));
            }
            else if (action == "Refuel")
            {
                currentVehicle.Refuel(argument);
            }

        }
        private void Print()
        {
            foreach (var item in this.vehicles)
            {
                writer.WriteLine(item);
            }
        }
    }

}
