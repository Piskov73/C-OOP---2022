using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                this.name = value;
            }
        }
        public int Capacity { get => this.capacity; private set => this.capacity = value; }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fish.AsReadOnly();
        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughCapacity));

            this.fish.Add(fish);
        }
        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }


        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string fishName = "none";
            if(this.fish.Count > 0)
            {
                List<string> names=new List<string>();
                foreach (var item in this.fish)
                {
                    names.Add(item.Name);
                }

                fishName = string.Join(", ", names);
            }

            sb.AppendLine($"{Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishName}")
                .AppendLine($"Decorations: {Decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

    }
}
