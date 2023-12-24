using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private HashSet<string> conqueredPeaks;
        public Climber(string name, int stamina)
        {
            this.Name = name;
            this.Stamina = stamina;
            this.conqueredPeaks= new HashSet<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value)) 
                    throw new ArgumentException(string.Format(ExceptionMessages.ClimberNameNullOrWhiteSpace));
                name=value;
            }
        }

        public int Stamina 
        {
            get => stamina;
            protected set
            {
                if (value > 10)
                {
                    value = 10;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                stamina=value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => this.conqueredPeaks.ToList().AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!this.conqueredPeaks.Contains(peak.Name))
            {
                this.conqueredPeaks.Add(peak.Name);
            }

            string difficultyLevel = peak.DifficultyLevel;

            if(difficultyLevel== "Extreme")
            {
                this.Stamina -= 6;
            }
            else if (difficultyLevel == "Hard")
            {
                this.Stamina -= 4;
            }
            else if (difficultyLevel == "Moderate")
            {
                this.Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);
      
    }
}
