using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private Stack<Item> items;
        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string type = args[0];
            string name = args[1];
            Character character;
            if (type == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else if (type == nameof(Priest))
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }
            this.characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;

            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            this.items.Push(item);


            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var character = this.characters.FirstOrDefault(n => n.Name == characterName);

            if (character == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            if (!this.items.Any())
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));

            var item = this.items.Pop();

            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = this.characters.FirstOrDefault(n => n.Name == characterName);

            if (character == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            var item=character.Bag.GetItem(itemName);

            item.AffectCharacter(character);

            return string.Format(SuccessMessages.UsedItem,characterName,itemName);
        }

        public string GetStats()
        {
            StringBuilder sb=new StringBuilder();
            foreach (var ch in this.characters.OrderByDescending(x=>x.Health))
            {
                string status = ch.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.BaseArmor}, Status: {status}");
                   
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string 	attackerName = args[0];

            var attacker=this.characters.FirstOrDefault(x=>x.Name==attackerName);
            if(attacker == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,attackerName));

            string 	receiverName= args[1];

            var receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));

            if(attacker.GetType().Name!=nameof(Warrior))
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));

            (attacker as Warrior).Attack(receiver);

            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} " +
                $"HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if(!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string 	healerName= args[0];
            var healer=this.characters.FirstOrDefault(n=>n.Name==healerName);
            if(healer == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,healerName));


            string 	healingReceiverName= args[1];
            var healing = this.characters.FirstOrDefault(n => n.Name == healingReceiverName);
            if (healer == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));

            if(healer.GetType().Name!=nameof(Priest))
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));

            (healer as Priest).Heal(healing);

            return $"{healer.Name} heals {healing.Name} for {healer.AbilityPoints}! " +
                $"{healing.Name} has {healing.Health} health now!";
        }
    }
}
