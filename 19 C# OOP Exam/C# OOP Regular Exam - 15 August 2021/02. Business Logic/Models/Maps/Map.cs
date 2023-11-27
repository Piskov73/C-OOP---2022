using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string output = string.Empty;
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                output = string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else if(!racerOne.IsAvailable())
            {
                output = string.Format(OutputMessages.OneRacerIsNotAvailable,racerTwo.Username,racerOne.Username);
                
            }
            else if(!racerTwo.IsAvailable())
            {
                output = string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();
                double multiplierOne=0;
                double multiplierTwo=0;
                if (racerOne.RacingBehavior == "aggressive")
                {
                    multiplierOne = 1.1;
                }
                else
                {
                    multiplierOne = 1.2;
                }
                if (racerTwo.RacingBehavior == "aggressive")
                {
                    multiplierTwo = 1.1;
                }
                else
                {
                    multiplierTwo = 1.2;
                }
                double chanceOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplierOne;
                double chanceTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplierTwo;
                string winnerUsername = string.Empty;
                if (chanceOne>chanceTwo)
                {
                    winnerUsername = racerOne.Username;
                }
                else
                {
                    winnerUsername=racerTwo.Username;
                }

                output = output = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,winnerUsername);
            }

            return output;
        }
    }
}
