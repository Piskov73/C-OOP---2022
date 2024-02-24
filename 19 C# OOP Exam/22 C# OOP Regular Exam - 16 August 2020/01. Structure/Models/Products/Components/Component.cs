using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        private int generation;
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.generation = generation;
        }

        public int Generation { get => this.generation; }

        public override string ToString()
        {
            return base.ToString() + string.Format(SuccessMessages.ComponentToString, Generation);
        }
    }

}
