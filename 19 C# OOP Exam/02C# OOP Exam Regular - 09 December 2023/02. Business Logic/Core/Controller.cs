using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishs;
        public Controller()
        {
            this.divers = new DiverRepository();
            this.fishs = new FishRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            var diver = this.divers.GetModel(diverName);

            if (diver != null)
                return string.Format(OutputMessages.DiverNameDuplication, diverName, this.divers.GetType().Name);
            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            this.divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, this.divers.GetType().Name);
        }
        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            var fish = this.fishs.GetModel(fishName);

            if (fish != null)
                return string.Format(OutputMessages.FishNameDuplication, fishName, this.fishs.GetType().Name);

            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            this.fishs.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            var diver = this.divers.GetModel(diverName);

            if (diver == null)
                return string.Format(OutputMessages.DiverNotFound, this.divers.GetType().Name, diverName);

            var fish = this.fishs.GetModel(fishName);

            if (fish == null)
                return string.Format(OutputMessages.FishNotAllowed, fishName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                if (diver.OxygenLevel == 0)
                    diver.UpdateHealthStatus();

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);

                    diver.UpdateHealthStatus();

                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                diver.Miss(fish.TimeToCatch);
                if (diver.OxygenLevel == 0)
                    diver.UpdateHealthStatus();
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            diver.Hit(fish);


            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
        }
        public string HealthRecovery()
        {
            int count = 0;
            foreach (var diver in this.divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    count++;
                    diver.RenewOxy();
                    diver.UpdateHealthStatus();
                }
            }
            return string.Format(OutputMessages.DiversRecovered, count);
        }
        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            var diver = this.divers.GetModel(diverName);

            sb.AppendLine(diver.ToString())
                .AppendLine("Catch Report:");

            foreach (var item in diver.Catch)
            {
                var fish = this.fishs.GetModel(item);
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (var item in this.divers.Models.OrderByDescending(x => x.CompetitionPoints)
                .ThenByDescending(x => x.Catch.Count).ThenBy(x => x.Name))
            {
                if (!item.HasHealthIssues)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
