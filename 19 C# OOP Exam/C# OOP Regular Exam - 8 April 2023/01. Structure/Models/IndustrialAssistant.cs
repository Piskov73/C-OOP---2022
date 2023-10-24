namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private new const int BatteryCapacity = 40000;
        private new const int ConvertionCapacityIndex = 5000;

        public IndustrialAssistant(string model) 
            : base(model, BatteryCapacity, ConvertionCapacityIndex)
        {
        }
    }
}
