﻿using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int STAMINA = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, STAMINA)
        {
        }

        public override void Exercise()
        {
            base.Stamina += 10;
            if (base.Stamina > 100)
            {
                base.Stamina = 100;
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
