using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
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
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }



        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }




        public int BatteryLevel { get => batteryLevel; private set => batteryLevel = value; }

        public int ConvertionCapacityIndex { get => convertionCapacityIndex; private set => convertionCapacityIndex = value; }

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            int energi = minutes * this.ConvertionCapacityIndex;
            this.batteryLevel += energi;
            if (this.batteryLevel > this.batteryCapacity)
                this.batteryLevel = this.batteryCapacity;
        }
        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaceStandards.Add(supplement.InterfaceStandard);
            this.batteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.batteryLevel >= consumedEnergy)
            {
                this.batteryLevel-=consumedEnergy;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string standards = "";
            if (InterfaceStandards.Count == 0)
            {
                standards = "none";
            }
            else
            {
                standards = string.Join(" ", InterfaceStandards);
            }

            sb.AppendLine($"{this.GetType().Name} {Model}:")
                .AppendLine($"--Maximum battery capacity: {BatteryCapacity}")
                .AppendLine($"--Current battery level: {BatteryLevel}")
                .AppendLine($"--Supplements installed: {standards}");


            return sb.ToString().TrimEnd();
        }

    }
}
