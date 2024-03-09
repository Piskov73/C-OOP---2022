using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmen;
        private HashSet<IGym> gyms;
        public Controller()
        {
            this.equipmen = new EquipmentRepository();
            this.gyms = new HashSet<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }

            this.gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEquipmentType));
            }

            this.equipmen.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            var equipmen = this.equipmen.FindByType(equipmentType);
            if (equipmen == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipmen);

            this.equipmen.Remove(equipmen);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            IAthlete athlete;
            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAthleteType));
            }

            if ((gym.GetType() == typeof(BoxingGym) && athlete.GetType() == typeof(Weightlifter))
                || (gym.GetType() == typeof(WeightliftingGym) && athlete.GetType() == typeof(Boxer)))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }
        public string TrainAthletes(string gymName)
        {
            var gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count());
        }



        public string EquipmentWeight(string gymName)
        {
            var gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, $"{gym.EquipmentWeight:f2}");
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
