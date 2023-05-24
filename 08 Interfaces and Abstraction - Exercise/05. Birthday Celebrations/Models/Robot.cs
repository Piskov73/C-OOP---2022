namespace BirthdayCelebrations.Models
{
using Interface;
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this .ID = id;
        }
        public string Model { get; private set; }

        public string ID { get; private set; }
    }
}
