using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        }

        public IReadOnlyCollection<IComponent> Components =>this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();
        public override decimal Price => base.Price+this.components.Sum(c=>c.Price)+this.peripherals.Sum(p=>p.Price);
        public override double OverallPerformance => base.OverallPerformance+this.components.Average(c=>c.OverallPerformance);
        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
                throw new ArgumentException(string.Format(ExceptionMessages
                    .ExistingComponent,component.GetType().Name,this.GetType().Name,this.Id));
            this.components.Add(component);
        }
        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(c=>c.GetType().Name == componentType);
            if (component == null)
                throw new ArgumentException(string.Format(ExceptionMessages
                    .NotExistingComponent,componentType,this.GetType().Name,this.Id));
            this.components.Remove(component);

            return component;
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            if(this.peripherals.Any(p=>p.GetType().Name == peripheral.GetType().Name))
                throw new ArgumentException(string.Format(ExceptionMessages
                    .ExistingPeripheral,peripheral.GetType().Name,this.GetType().Name ,this.Id));

            this.peripherals.Add(peripheral);
        }

   

        public IPeripheral RemovePeripheral(string peripheralType)
        {
           var peripheral = this.peripherals.FirstOrDefault(p=>p.GetType().Name==peripheralType);
            if(peripheral== null)
                throw new ArgumentException(string.Format(ExceptionMessages
                    .NotExistingPeripheral,peripheralType,this.GetType().Name,this.Id));

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})")
            .AppendLine($" Components ({Components.Count}):");
            foreach(var component in components)
            {
                sb.AppendLine(component.ToString());
            }
            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(p=>p.OverallPerformance):f2}):");
            foreach (var peripheral in peripherals)
            {
                sb.AppendLine(peripheral.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
