﻿using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;
        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
            this.NumberOfMedals = numberOfMedals;
        }
        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAthleteName));

                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAthleteMotivation));

                this.motivation = value;
            }
        }

        public int Stamina { get => this.stamina; protected set => this.stamina = value; }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAthleteMedals));
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();

    }
}
