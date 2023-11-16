using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Heroes.Core
{
    public class Controller : IController
    {

        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller() 
        {
            this.heroes=new HeroRepository();
            this.weapons=new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            var hero=this.heroes.FindByName(name);
            if(hero != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist,name));
            }

            if (type == nameof(Barbarian))
            {
                hero=new Barbarian(name, health, armour);
            }
            else if(type == nameof(Knight))
            {
                hero=new Knight(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroTypeIsInvalid));
            }

            this.heroes.Add(hero);

            string result=string.Empty;

            if(type==nameof(Knight))
            {
                result = string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }
            else
            {
                result = string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }

            return result;
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            var weapon=this.weapons.FindByName(name);
            if(weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists,name));
            }
            if(type == nameof(Claymore))
            {
                
                weapon=new Claymore(name, durability);
            }
            else if(type == nameof(Mace))
            {
                weapon=new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponTypeIsInvalid));
            }

            this.weapons.Add(weapon);
            return string.Format(OutputMessages.WeaponAddedSuccessfully,type.ToLower(),name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero=this.heroes.FindByName(heroName);
            if(hero == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist,heroName));
            }

            var weapon = this.weapons.FindByName(weaponName);
            if(weapon == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            if(hero.Weapon!=null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }
            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            return string.Format(OutputMessages.WeaponAddedToHero,heroName,weapon.GetType().Name.ToLower());
        }

        public string StartBattle()
        {
            var map = new Map();

            return map.Fight(heroes.Models.ToList());
        }


        public string HeroReport()
        {
           StringBuilder sb=new StringBuilder();

            var heroesFilter=this.heroes.Models.OrderBy(x=>x.GetType().Name).ThenByDescending(h=>h.Health).ThenBy(n=>n.Name);

            foreach (var item in heroesFilter)
            {
                string temt = string.Empty;

                if (item.Weapon == null)
                {
                    temt = "Unarmed";
                }
                else
                {
                    temt=item.Weapon.Name;
                }

                sb.AppendLine($"{item.GetType().Name}: {item.Name}")
                    .AppendLine($"--Health: {item.Health}")
                    .AppendLine($"--Armour: {item.Armour}")
                    .AppendLine($"--Weapon: {temt}");
                   
            }

            return sb.ToString().TrimEnd();
        }

    }
}
