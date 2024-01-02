namespace RobotService.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using RobotService.Utilities.Messages;

    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int conversionCapacityIndex;
        private int batteryLevel;
        private List<int> interfaceStandards;
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.ConvertionCapacityIndex = conversionCapacityIndex;
            this.BatteryLevel = batteryCapacity;
            this.interfaceStandards = new List<int>();
        }
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNullOrWhitespace));
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.BatteryCapacityBelowZero));

                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get => batteryLevel; private set => batteryLevel = value; }

        public int ConvertionCapacityIndex { get => conversionCapacityIndex; private set => conversionCapacityIndex = value; }

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            this.BatteryLevel += minutes * ConvertionCapacityIndex;
            if (this.BatteryLevel > this.BatteryCapacity)
                this.BatteryLevel = this.BatteryCapacity;
        }
        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }
        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                this.BatteryLevel-= consumedEnergy;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string standard = "none";
            if(InterfaceStandards.Count > 0)
            {
                standard = string.Join(" ", InterfaceStandards);
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {Model}:")
                .AppendLine($"--Maximum battery capacity: {BatteryCapacity}")
                .AppendLine($"--Current battery level: {BatteryLevel}")
                .AppendLine($"--Supplements installed: {standard}");

            return sb.ToString().TrimEnd();
        }
    }
}
