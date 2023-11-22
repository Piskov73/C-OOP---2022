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
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber=mainWeaponCaliber;
            Speed=speed;
            ArmorThickness=armorThickness;
            this.targets=new List<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
            set
            {
                if (value < 0)
                    value = 0;

                armorThickness = value;
            }

        }

        public double MainWeaponCaliber { get => mainWeaponCaliber; protected set => mainWeaponCaliber = value; }

        public double Speed { get => speed; protected set => speed = value; }

        public ICollection<string> Targets => targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));

            target.ArmorThickness -= MainWeaponCaliber;
        }

        public virtual void RepairVessel()
        {
            
        }

        public override string ToString()
        {
            string target=string.Empty;
            if(Targets.Count == 0)
            {
                target = "None";
            }
            else
            {
                target=string.Join(", ",Targets);
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Armor thickness: {ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
                .AppendLine($" *Speed: {Speed} knots")
                .AppendLine($"Targets: {target}");


            return sb.ToString().TrimEnd();
        }
    }
}
