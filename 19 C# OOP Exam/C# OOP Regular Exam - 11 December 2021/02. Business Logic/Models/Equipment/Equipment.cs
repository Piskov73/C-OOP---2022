using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;
        public Equipment(double weight, decimal price)
        {
            this.weight = weight;
            this.price = price;
        }
        public double Weight => this.weight;

        public decimal Price => this.price;
    }
}
