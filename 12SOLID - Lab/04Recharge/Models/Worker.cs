namespace Recharge.Models
{
    using Interfaces;
    public abstract class Worker : IWorker
    {
        private string id;
        private int workingHours;
        public Worker(string id)
        {
            this.id = id;
        }
        public string ID => id;
        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}
