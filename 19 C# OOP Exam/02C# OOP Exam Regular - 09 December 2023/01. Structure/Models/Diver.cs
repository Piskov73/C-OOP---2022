using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private double competitionPoints = 0;
        private bool hasHealthIssues=false;
        private HashSet<string> fishNames;

        public Diver(string name, int oxygenLevel) 
        {
            Name= name;
            OxygenLevel= oxygenLevel;
            fishNames= new HashSet<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.DiversNameNull));
                
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if(value<0)
                    value=0;

                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => this.fishNames.ToList().AsReadOnly();

        public double CompetitionPoints =>Math.Round(competitionPoints,1);

        public bool HasHealthIssues => hasHealthIssues;

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this.fishNames.Add(fish.Name);
            this.competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);


        public abstract void RenewOxy();
       

        public void UpdateHealthStatus()
        {
            this.hasHealthIssues=!this.HasHealthIssues;
        }
        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
