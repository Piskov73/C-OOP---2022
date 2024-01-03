namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int BATTERY_CAPACITY = 20000;
        private const int CONVERSION_INDEX = 2000;
        public DomesticAssistant(string model)
            : base(model, BATTERY_CAPACITY, CONVERSION_INDEX)
        {
        }
    }
}
