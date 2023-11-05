using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int id = this.booths.Models.Count+1;

            Booth booth = new Booth(id,capacity);

            this.booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded,id,capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
           var booth=this.booths.Models.FirstOrDefault(i=>i.BoothId==boothId);
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType,delicacyTypeName);
            }
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(n => n.Name == delicacyName);
            if (delicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded,delicacyName);
            }

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if(delicacyTypeName == nameof(Stolen))
            {
                delicacy= new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded,delicacyTypeName,delicacyName);

        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = this.booths.Models.FirstOrDefault(i => i.BoothId == boothId);

            if (cocktailTypeName!=nameof(Hibernation)&&cocktailTypeName!=nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType,cocktailTypeName);
            }
            if(size!= "Small"&&size!= "Middle"&&size!= "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize,size);
            }

            ICocktail cocktail=booth.CocktailMenu.Models.FirstOrDefault(c=>c.Name==cocktailName&&c.Size==size);
            if (cocktail!=null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded,size,cocktailName);
            }
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if(cocktailTypeName==nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded,size,cocktailName,cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
           var listBooths=this.booths.Models.Where(b=>b.IsReserved==false&&b.Capacity>=countOfPeople)
                .OrderBy(c=>c.Capacity).ThenByDescending(i=>i.BoothId).ToList();
            var booth = listBooths.FirstOrDefault();
            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth,countOfPeople);
            }
            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully,booth.BoothId,countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string result = "";
            var booth = this.booths.Models.FirstOrDefault(i => i.BoothId == boothId);

            string itemTypeName = "";
            string itemName = "";
            int countpPieces = 0;
            string size = "";
            double amont = 0;
            IDelicacy delicacy;
            ICocktail cocktail;
            List<string> infoOrder=order.Split("/",StringSplitOptions.RemoveEmptyEntries).ToList();
            itemTypeName = infoOrder[0];
            if(itemTypeName!=nameof(Hibernation)&& itemTypeName != nameof(MulledWine) 
                && itemTypeName != nameof(Stolen) && itemTypeName != nameof(Gingerbread))
            {
                result= string.Format(OutputMessages.NotRecognizedType,itemTypeName);
            }

            else
            {
                itemName = infoOrder[1];
                countpPieces = int.Parse(infoOrder[2]);
                if (itemTypeName == nameof(Stolen) || itemTypeName == nameof(Gingerbread))
                {
                    
                    delicacy = booth.DelicacyMenu.Models.FirstOrDefault(n => n.Name == itemName);
                    if (delicacy == null)
                    {
                        result = string.Format(OutputMessages.NotRecognizedItemName,itemTypeName,itemName);
                    }
                    else
                    {
                         amont = delicacy.Price;
                        for (int i = 0; i < countpPieces; i++)
                        {
                            booth.UpdateCurrentBill(amont);
                        }
                        result = string.Format(OutputMessages.SuccessfullyOrdered,booth.BoothId,countpPieces,itemName);
                    }

                }
                else if(itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
                {
                    size = infoOrder[3];
                    cocktail=booth.CocktailMenu.Models.FirstOrDefault(c=>c.Name==itemName&&c.Size==size);
                    if(cocktail == null)
                    {
                        result = string.Format(OutputMessages.NotRecognizedItemName,size,itemName);
                    }
                    else
                    {
                         amont= cocktail.Price;
                        for (int i = 0; i < countpPieces; i++)
                        {
                            booth.UpdateCurrentBill(amont);
                        }
                        result = string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countpPieces, itemName);

                    }
                }
            }

          

            return result;
        }
        public string LeaveBooth(int boothId)
        {
            var booth = this.booths.Models.FirstOrDefault(i => i.BoothId == boothId);
           
            
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv")
                .AppendLine($"Booth {booth.BoothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd() ;
        }

        public string BoothReport(int boothId)
        {
            var booth = this.booths.Models.FirstOrDefault(i => i.BoothId == boothId);

            return booth.ToString();

        }



    }
}
