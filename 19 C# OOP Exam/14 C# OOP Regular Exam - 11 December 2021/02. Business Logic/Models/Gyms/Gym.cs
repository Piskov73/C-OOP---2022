using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }
                this.name = value;
            }
        }

        public int Capacity => this.capacity;

        public double EquipmentWeight => this.equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => this.equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => this.athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count == this.capacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughSize));
            }
            this.athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string athleteName = "No athletes";
            if (this.athletes.Count > 0)
            {
                List<string> athletesNames = this.athletes.Select(x=>x.FullName).ToList();
              

                athleteName = string.Join(", ", athletesNames);
            }
            sb.AppendLine($"{Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {athleteName}")
                .AppendLine($"Equipment total count: {this.equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();

        }
    }
}
