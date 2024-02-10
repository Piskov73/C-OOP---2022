using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private HashSet<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new HashSet<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));

            aquarium.AddDecoration(decoration);

            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            IFish fish;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType==nameof(SaltwaterFish))
            {
                fish=new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }

            if(fishType==nameof(FreshwaterFish)&&aquarium.GetType().Name==nameof(SaltwaterAquarium)
                || fishType == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }

            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium,fishType,aquariumName);
        }
        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();

            int fedCount = aquarium.Fish.Count;

            return string.Format(OutputMessages.FishFed,fedCount);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal priceAquarium=aquarium.Fish.Sum(x=> x.Price)+aquarium.Decorations.Sum(x=>x.Price);

            return string.Format(OutputMessages.AquariumValue,aquariumName,$"{priceAquarium:f2}");
        }



        public string Report()
        {
            StringBuilder sb=new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
