namespace BirthdayCelebrations.Metods
{
    using Interfaces;

    public class Robot : IRobot , IPersonallyID
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.ID=id;
        }
        public string Model { get;private set; }

        public string ID { get; private set; }
    }
}
