using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly BoothRepository booths;
        public Controller()
        {
            this.booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int id = this.booths.Models.Count + 1;

            this.booths.AddModel(new Booth(id, capacity));

            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            ICocktail cocktail;

            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName && x.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var filterBoths = this.booths.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).ToList();
            var both = filterBoths.FirstOrDefault();
            if (both == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            both.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, both.BoothId, countOfPeople);
        }
        public string TryOrder(int boothId, string order)
        {

            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            var orderDetail = order.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            string itemTypeName = orderDetail[0];
            string itemName = orderDetail[1];
            int pieces = int.Parse(orderDetail[2]);
            string size = string.Empty;
            if (orderDetail.Count == 4)
            {
                size = orderDetail[3];
            }

            if (itemTypeName != nameof(Stolen) && itemTypeName != nameof(Gingerbread)
                && itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
            if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName) && !booth.DelicacyMenu.Models.Any(x => x.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            string output = string.Empty;

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                var cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName
                && x.Size == size && x.GetType().Name == itemTypeName);
                if (cocktail == null)
                {
                    output = string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
                else
                {
                    booth.UpdateCurrentBill(cocktail.Price * pieces);

                    output = string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
                }

            }
            else
            {
                var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName
                && x.GetType().Name == itemTypeName);
                if (delicacy == null)
                {
                    output = string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                else
                {
                    booth.UpdateCurrentBill(delicacy.Price * pieces);

                    output = string.Format(OutputMessages.SuccessfullyOrdered, boothId, pieces, itemName);
                }
            }

            return output;
        }
        public string LeaveBooth(int boothId)
        {
            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            double currentBill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv")
                .AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {boothId}")
                .AppendLine($"Capacity: {booth.Capacity}")
                .AppendLine($"Turnover: {booth.Turnover:f2} lv")
                .AppendLine($"-Cocktail menu:");
            foreach (var cocktail in booth.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in booth.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }
            return sb.ToString().TrimEnd();
        }



    }
}
