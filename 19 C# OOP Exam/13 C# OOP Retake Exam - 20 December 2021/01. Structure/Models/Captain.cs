using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private  int combatExperience;
        private  List<IVessel> vessels;
        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.combatExperience = 0;
            this.vessels= new List<IVessel>();
        }
        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));

                this.fullName = value;
            }
        }

        public int CombatExperience => this.combatExperience;

        public ICollection<IVessel> Vessels => this.vessels.AsReadOnly();

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidVesselForCaptain));
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if(Vessels.Count>0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
