namespace RobotService.Core
{
    using System.Text;
    using System.Linq;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private RobotRepository robots;
        private SupplementRepository supplements;
        public Controller()
        {
            this.robots = new RobotRepository();
            this.supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            this.robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;
            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            this.supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var robotFilter = this.robots.Models().Where(x => x.Model == model).ToList();
            var supplemen = this.supplements.Models().FirstOrDefault(t => t.GetType().Name == supplementTypeName);

            var robot = robotFilter.FirstOrDefault(r => !r.InterfaceStandards.Contains(supplemen.InterfaceStandard));

            if (robot == null)
                return string.Format(OutputMessages.AllModelsUpgraded, model);

            robot.InstallSupplement(supplemen);

            this.supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var filterRobots = this.robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(x => x.BatteryLevel).ToList();
            if (filterRobots.Count==0)
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);

            if (totalPowerNeeded > filterRobots.Sum(x => x.BatteryLevel))
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - filterRobots
                    .Sum(x => x.BatteryLevel));

            int count = 0;
            foreach (var robot in filterRobots)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    count++;
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    count++;
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
        }
        public string RobotRecovery(string model, int minutes)
        {
            var robotsFilter = this.robots.Models().Where(m => m.Model == model);
            int count = 0;
            foreach (var robot in robotsFilter)
            {
                if (robot.BatteryLevel * 2 < robot.BatteryCapacity)
                {
                    count++;
                    robot.Eating(minutes);
                }
            }
            return string.Format(OutputMessages.RobotsFed, count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var robot in this.robots.Models().OrderByDescending(x => x.BatteryLevel)
                .ThenBy(x => x.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
