using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
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
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private IWorkshop workshop;
        private int countColoredEggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidBunnyType));
            }

            this.bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {

            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentBunny));

            IDye dye = new Dye(power);

            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggs.FindByName(eggName);

            List<IBunny> bunniesWork = this.bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            foreach (var buuny in bunniesWork)
            {
                this.workshop.Color(egg, buuny);
                if (buuny.Energy == 0)
                {
                    this.bunnies.Remove(buuny);
                }
                if (egg.IsDone())
                {
                    break;
                }
               
            }

            if (egg.IsDone())
            {
                countColoredEggs++;
                return string.Format(OutputMessages.EggIsDone, eggName);
            }

            return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countColoredEggs} eggs are done!")
                .AppendLine("Bunnies info:");
            foreach (var bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}")
                    .AppendLine($"Energy: {bunny.Energy}");
                int countDyes = 0;
                foreach (var dye in bunny.Dyes)
                {
                    if (!dye.IsFinished())
                        countDyes++;

                }
                sb.AppendLine($"Dyes: {countDyes} not finished");
            }



            return sb.ToString().TrimEnd();
        }
    }
}
