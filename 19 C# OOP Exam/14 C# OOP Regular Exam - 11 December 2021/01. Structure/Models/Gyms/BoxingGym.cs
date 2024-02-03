namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int MaxCapacity = 15;
        public BoxingGym(string name) 
            : base(name, MaxCapacity)
        {
        }
    }
}
