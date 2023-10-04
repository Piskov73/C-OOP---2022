namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Formula1.Utilities;

    public class Race : IRace
    {
        private string raceNamer;
        private int numberOfLaps;
        private List<IPilot> pilots;



        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();

        }

        public string RaceName
        {
            get { return raceNamer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceNamer = value;
            }
        }


        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }


        public bool TookPlace { get; set; }


        public ICollection<IPilot> Pilots => this.pilots.AsReadOnly();

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookPlace = TookPlace ? "Yes" : "No";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {raceNamer} race has:")
                .AppendLine($"Participants: {Pilots.Count}")
                .AppendLine($"Number of laps: {numberOfLaps}")
                .AppendLine($"Took place: {tookPlace}");
            return sb.ToString().TrimEnd();
        }
    }
}
