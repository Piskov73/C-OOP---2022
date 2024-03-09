using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int STAMINA = 50;
        private const int INCREASE_STAMINA = 10;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, STAMINA)
        {
        }

        public override void Exercise()
        {
            base.Stamina += INCREASE_STAMINA;
            if (base.Stamina > 100)
            {
                base.Stamina = 100;

                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
