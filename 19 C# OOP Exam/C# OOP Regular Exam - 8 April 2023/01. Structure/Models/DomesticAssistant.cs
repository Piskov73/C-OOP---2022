using System;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private new const int BatteryCapacity = 20000;
        private new const int ConvertionCapacityIndex = 2000;


        public DomesticAssistant(string model)
            : base(model, BatteryCapacity, ConvertionCapacityIndex)
        {
        }
    }
}
