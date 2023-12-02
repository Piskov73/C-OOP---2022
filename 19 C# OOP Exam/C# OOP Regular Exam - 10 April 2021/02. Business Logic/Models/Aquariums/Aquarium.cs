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
            Name = name;
            this.capacity = capacity;
            this .decorations = new List<IDecoration>();
            this .fish = new List<IFish>();

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))

                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));

                name = value;
            }
        }


        public int Capacity => this.capacity;

        public int Comfort => Decorations.Sum(d=>d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fish.AsReadOnly();

        public void AddFish(IFish fish)
        {
            if (Fish.Count == Capacity)
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
            foreach (var fi in this.fish)
            {
                fi.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string fishName = string.Empty;
            if(this.fish.Count== 0)
            {
                fishName = "none";
            }
            else
            {
                List<string> names=this.fish.Select(fish => fish.Name).ToList();
                fishName=string.Join(", ",names);
            }

            sb.AppendLine($"{Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishName}")
                .AppendLine($"Decorations: {this.decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

    }
}
