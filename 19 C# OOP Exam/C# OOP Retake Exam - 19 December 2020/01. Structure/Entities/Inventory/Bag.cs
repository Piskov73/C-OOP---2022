using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity { get; set; } = 100;

        public int Load => this.items.Sum(s=>s.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > this.Capacity)
                throw new InvalidOperationException(string.Format(ExceptionMessages.ExceedMaximumBagCapacity));

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if(!this.Items.Any())
                throw new InvalidOperationException(string.Format(ExceptionMessages.EmptyBag));

            var item=this.items.FirstOrDefault(i=>i.GetType().Name == name);

            if(item == null)
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag,name));

            return item;
        }
    }
}
