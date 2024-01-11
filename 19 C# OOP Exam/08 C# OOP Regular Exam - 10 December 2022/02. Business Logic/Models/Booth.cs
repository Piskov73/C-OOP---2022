using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private readonly DelicacyRepository delicacyRepository;
        private readonly CocktailRepository cocktailRepository;
        private double currentBill;
        private double turnover;
        private bool isReserved;
        public Booth(int boothId, int capacity)
        {
            this.BoothId=boothId;
            this.Capacity=capacity;
            this.delicacyRepository = new DelicacyRepository();
            this.cocktailRepository = new CocktailRepository();
            this.currentBill = 0;
            this.turnover = 0;
            this.isReserved = false;
        }
        public int BoothId { get => boothId; private set => boothId = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyRepository;

        public IRepository<ICocktail> CocktailMenu => this.cocktailRepository;

        public double CurrentBill => this.currentBill;

        public double Turnover => this.turnover;

        public bool IsReserved => this.isReserved;

        public void ChangeStatus()
        {
           this.isReserved=!this.isReserved;
        }

        public void Charge()
        {
            this.turnover += this.currentBill;
            this.currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill+= amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Turnover: {Turnover:f2} lv")
                .AppendLine($"-Cocktail menu:");
            foreach (var item in cocktailRepository.Models)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var item in delicacyRepository.Models)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
