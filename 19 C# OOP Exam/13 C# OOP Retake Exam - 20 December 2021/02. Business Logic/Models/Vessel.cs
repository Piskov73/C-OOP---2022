using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double mainWeaponCaliber;
        private double armorThickness;
        private  List<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));

                this.captain = value;
            }
        }
        public double ArmorThickness { get => this.armorThickness; set => this.armorThickness = value; }

        public double MainWeaponCaliber { get => this.mainWeaponCaliber; protected set => this.mainWeaponCaliber = value; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => this.targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));

            if (target.ArmorThickness >= this.MainWeaponCaliber)
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }
            else
            {
                target.ArmorThickness = 0;
            }

            this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new();

            string nameTargets = "None";
            if(Targets.Count>0)
            {
                nameTargets = string.Join(", ", Targets);
            }
            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Armor thickness: {ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
                .AppendLine($" *Speed: {Speed} knots")
                .AppendLine($" *Targets: {nameTargets}");

            return sb.ToString().TrimEnd();
        }

    }
}
