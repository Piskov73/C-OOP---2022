namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int MaxCapacity = 20;
        public WeightliftingGym(string name) 
            : base(name, MaxCapacity)
        {
        }
    }
}
