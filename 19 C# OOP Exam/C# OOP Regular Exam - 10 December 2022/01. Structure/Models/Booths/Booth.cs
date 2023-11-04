using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private double currentBill;
        private double turnover;
        private bool isReserved;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu= new CocktailRepository();
        }

        public int BoothId { get=>boothId;private set=>boothId = value; }


        public int Capacity
        {
            get { return capacity; }
          private  set
            {
                if (value < 1)
                    throw new AggregateException(string.Format(ExceptionMessages.CapacityLessThanOne));
                capacity = value;
            }
        }


        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;

        public double CurrentBill { get=>currentBill;private set=>currentBill = value; }

        public double Turnover { get => turnover;private set => turnover = value; }

        public bool IsReserved { get => isReserved;private set => isReserved = value; }

        public void ChangeStatus()
        {
            if (IsReserved) this.isReserved = false;
            else this.isReserved=true;
        }

        public void Charge()
        {
            this.turnover += CurrentBill;
            this.currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Turnover: {Turnover:f2} lv")
                .AppendLine($"-Cocktail menu:");
            foreach ( var item in CocktailMenu.Models )
            {
                sb.AppendLine($"--{item}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
