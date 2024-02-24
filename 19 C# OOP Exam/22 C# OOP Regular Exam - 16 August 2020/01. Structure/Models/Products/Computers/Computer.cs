using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private HashSet<IComponent> components;
        private HashSet<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new HashSet<IComponent>();
            this.peripherals = new HashSet<IPeripheral>();
        }

        public override double OverallPerformance => base.OverallPerformance + CalculateAveragePerformance();

        public override decimal Price => CalculatePrice();
        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();


        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType() == component.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent
                    , component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }
        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent
                    , componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if(this.peripherals.Any(x=>x.GetType() == peripheral.GetType()))
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral
                   , peripheral.GetType().Name, this.GetType().Name, this.Id));
            
            this.peripherals.Add(peripheral);
        }


        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if(peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral
                  , peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        private double CalculateAveragePerformance()
        {
            double resuult = 0;

            if (this.components.Count > 0)
            {
                resuult += this.components.Average(x => x.OverallPerformance);
            }
            return resuult;
        }
        private decimal CalculatePrice()
        {
            decimal resuult = base.Price;
            if (this.components.Count > 0)
            {
                resuult += this.components.Sum(x => x.Price);
            }
            if (this.peripherals.Count > 0)
            {
                resuult += this.peripherals.Sum(x => x.Price);
            }

            return resuult;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format(SuccessMessages.ComputerComponentsToString, this.components.Count));
            foreach (var component in this.components)
            {
                sb.AppendLine(component.ToString());
            }
            sb.AppendLine(string.Format(SuccessMessages.ComputerPeripheralsToString
                , this.peripherals.Count, CalculateAveragePerformance()));

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine(peripheral.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
