using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {

        //        •	bunnies - BunnyRepository 
        //•	eggs - EggRepository

        private BunnyRepository bunnies;
        private EggRepository eggs;
        private Workshop workshop;
        private int countColor;

        public Controller()
        {
            bunnies=new BunnyRepository();
            eggs=new EggRepository();
            workshop=new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if(bunnyType== nameof(SleepyBunny))
            {
                bunny=new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidBunnyType));
            }
            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded,bunnyType,bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
           var bunny=bunnies.FindByName(bunnyName);
            if (bunny == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentBunny));

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded,power,bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
         IEgg egg=new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg=eggs.FindByName(eggName);

            List<IBunny> bunniesFilter = bunnies.Models.Where(p => p.Energy >= 50).OrderByDescending(p => p.Energy).ToList();

            if(bunniesFilter.Count==0)
                throw new InvalidOperationException(string.Format(ExceptionMessages.BunniesNotReady));

            foreach (var bunny in bunniesFilter)
            {
                workshop.Color(egg,bunny);
                if (bunny.Energy == 0) 
                    bunnies.Remove(bunny);

                if (egg.IsDone())
                {

                    countColor++;
                    break;

                }
            }

            string workDone = egg.IsDone() ? "done" : "not done";

            return $"Egg {eggName} is {workDone}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countColor} eggs are done!")
                .AppendLine($"Bunnys info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
