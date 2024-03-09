namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int CAPACITY = 10;
        public WeightliftingGym(string name ) 
            : base(name, CAPACITY)
        {
        }
    }
}
