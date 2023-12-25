using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;


namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        private string name;
        private int elevation;
        private string difficultyLevel;
        public Peak(string name, int elevation, string difficultyLevel)
        { 
           this. Name=name;
            this.Elevation=elevation;
            this.difficultyLevel=difficultyLevel;
        }
        public string Name
        { 
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.PeakNameNullOrWhiteSpace));

                name = value; 
            }
        }

        public int Elevation
        {
            get => elevation;
            private set
            {
                if(value<=0)
                    throw new ArgumentException(string.Format(ExceptionMessages.PeakElevationNegative));

                elevation = value;
            }
        }

        public string DifficultyLevel =>this.difficultyLevel;

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}
