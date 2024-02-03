﻿using Gym.Core.Contracts;
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
using System.Net.Http.Headers;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private HashSet<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new HashSet<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
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
           IEquipment equipmentAdd;

            if (equipmentType == nameof(Kettlebell))
            {
                equipmentAdd=new Kettlebell();
            }
            else if(equipmentType==nameof(BoxingGloves))
            {
                equipmentAdd=new BoxingGloves();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEquipmentType));
            }

            this.equipment.Add(equipmentAdd);
            
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym=this.gyms.FirstOrDefault(n=>n.Name==gymName);
            if (gym == null)
                return null;
            var equipment = this.equipment.FindByType(equipmentType);

            if(equipment == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,equipmentType));

           gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym,equipmentType,gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = this.gyms.FirstOrDefault(n => n.Name == gymName);
            if (gym == null)
                return null;

            IAthlete athlete;

            if(athleteType == nameof(Boxer))
            {
                athlete=new Boxer(athleteName, motivation,numberOfMedals);
            }
            else if(athleteType == nameof(Weightlifter))
            {
                athlete=new Weightlifter(athleteName, motivation,numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAthleteType));
            }

            if(athleteType==nameof(Boxer)&&gym.GetType().Name==nameof(WeightliftingGym)
                ||athleteType==nameof(Weightlifter)&&gym.GetType().Name==nameof(BoxingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym,athleteType,gymName);
        }

        public string TrainAthletes(string gymName)
        {
            var gym = this.gyms.FirstOrDefault(n => n.Name == gymName);
            if (gym == null)
                return null;

            foreach(var athl in gym.Athletes)
            {
                athl.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }


        public string EquipmentWeight(string gymName)
        {
            var gym = this.gyms.FirstOrDefault(n => n.Name == gymName);
            if (gym == null)
                return null;

            return string.Format(OutputMessages.EquipmentTotalWeight,gymName,gym.EquipmentWeight);
        }


        public string Report()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
