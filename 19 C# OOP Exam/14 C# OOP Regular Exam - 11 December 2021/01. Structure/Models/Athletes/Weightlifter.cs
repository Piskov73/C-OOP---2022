using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;
        private const int ExerciseStamina = 10;
        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            base.Stamina += ExerciseStamina;
            if (base.Stamina > 100)
            {
                base.Stamina = 100;

                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}

