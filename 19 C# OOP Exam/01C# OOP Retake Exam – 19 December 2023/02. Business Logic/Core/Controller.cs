using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;

        public Controller()
        {
            this.peaks = new PeakRepository();
            this.climbers = new ClimberRepository();
            this.baseCamp = new BaseCamp();
        }
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            var peak = this.peaks.Get(name);
            if (peak != null)
                return string.Format(OutputMessages.PeakAlreadyAdded, name);

            if(difficultyLevel!= "Extreme" && difficultyLevel!= "Hard" && difficultyLevel!= "Moderate")
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);

            peak=new Peak(name, elevation, difficultyLevel);

            this.peaks.Add(peak);

            return string.Format(OutputMessages.PeakIsAllowed, name,this.peaks.GetType().Name);
        }
        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            var climber = this.climbers.Get(name);

            if(climber!=null)
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, this.climbers.GetType().Name);

            if (isOxygenUsed)
            {
                climber=new OxygenClimber(name);
            }
            else
            {
                climber=new NaturalClimber(name);
            }
            this.climbers.Add(climber);
            this.baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            var climber = this.climbers.Get(climberName);
            if(climber==null)
                return string.Format(OutputMessages.ClimberNotArrivedYet,climberName);

            var peak =this.peaks.Get(peakName);
            if(peak==null)
                return string.Format(OutputMessages.PeakIsNotAllowed,peakName);

            if(!this.baseCamp.Residents.Contains(climberName))
                 return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName,peakName);

            if(climber.GetType().Name == nameof(NaturalClimber)&&peak.DifficultyLevel== "Extreme")
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel,climberName,peakName);

            this.baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }

            this.baseCamp.ArriveAtCamp(climberName);

            return string.Format(OutputMessages.SuccessfulAttack, climberName,peakName);

        }
        public string CampRecovery(string climberName, int daysToRecover)
        {
           if(!this.baseCamp.Residents.Contains(climberName))
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);

            var climber = this.climbers.Get(climberName);

            if(climber.Stamina==10)
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);

            climber.Rest(daysToRecover);

            return string.Format(OutputMessages.ClimberRecovered, climberName,daysToRecover);
        }

        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            foreach (var item in this.baseCamp.Residents)
            {
                var climber = this.climbers.Get(item);

                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().TrimEnd();
        }



        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            foreach (var climber in this.climbers.All.OrderByDescending(x=>x.ConqueredPeaks.Count).ThenBy(x=>x.Name))
            {
                List<IPeak> climberPeaks = new List<IPeak>();
                sb.AppendLine(climber.ToString());
                foreach (var peakName in climber.ConqueredPeaks)
                {
                    var peak = this.peaks.Get(peakName);
                    climberPeaks.Add(peak);
                }
                foreach (var peak in climberPeaks.OrderByDescending(x=>x.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
