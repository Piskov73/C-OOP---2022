using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        private const int ExerciseStamina = 15;
        public Boxer(string fullName, string motivation, int numberOfMedals) 
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
