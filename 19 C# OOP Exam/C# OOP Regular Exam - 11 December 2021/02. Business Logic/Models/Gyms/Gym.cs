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
            Name = name;
            this.capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidGymName));   
                name = value;
            }
        }


        public int Capacity => this.capacity;

        public double EquipmentWeight => this.equipment.Sum(e=>e.Weight);

        public ICollection<IEquipment> Equipment => this.equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => this.athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == Athletes.Count)
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughSize));

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
            if(Athletes.Count>0)
            {
                foreach (var athlet in this.athletes)
                {
                    athlet.Exercise();
                }
            }
        }

        public string GymInfo()
        {
            string athleteName = string.Empty;
            if (Athletes.Count == 0)
            {
                athleteName = "No athletes";
            }
            else
            {
                List <string > names=this.athletes.Select(n=>n.FullName).ToList();
                athleteName=string.Join(", ",names);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {athleteName}")
                .AppendLine($"Equipment total count: {Equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");


            return sb.ToString().TrimEnd();
        }

    }
}
