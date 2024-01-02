namespace RobotService.Models
{
    using Contracts;
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandard;
        private int batteryUsage;
        public Supplement(int interfaceStandard, int batteryUsage)
        {
            this.InterfaceStandard = interfaceStandard;
            this.BatteryUsage = batteryUsage;
        }
        public int InterfaceStandard { get=>interfaceStandard;private set=>interfaceStandard = value; }

        public int BatteryUsage { get=>batteryUsage;private set=>batteryUsage = value; }
    }
}
