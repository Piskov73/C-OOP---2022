using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        private IMap map;
        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
            map=new Map();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            var hero = this.heroes.FindByName(name);

            if (hero != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroTypeIsInvalid));
            }

            this.heroes.Add(hero);
            if (type == nameof(Knight))
            {
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }
            return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            var weapon = this.weapons.FindByName(name);

            if (weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }

            if (type == nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
            }
            else if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponTypeIsInvalid));
            }

            this.weapons.Add(weapon);

            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = this.heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist,heroName));
            }

            var weapon = this.weapons.FindByName(weaponName);

            if(weapon == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            if (hero.Weapon != default)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon,heroName));
            }

            hero.AddWeapon(weapon);

            this.weapons.Remove(weapon);

            return string.Format(OutputMessages.WeaponAddedToHero,heroName,weapon.GetType().Name.ToLower());
        }


        public string StartBattle()
        {
           List<IHero> heroesBattle=this.heroes.Models.Where(x=>x.IsAlive==true&&x.Weapon!=default).ToList();

            return map.Fight(heroesBattle);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.heroes.Models.OrderBy(x=>x.GetType().Name)
                .ThenByDescending(x=>x.Health).ThenBy(x=>x.Name))
            {
                string weaponName = "Unarmed";
                if (hero.Weapon != default)
                {
                    weaponName=hero.Weapon.Name;
                }

                sb.AppendLine($"{ hero.GetType().Name }: { hero.Name }")
               .AppendLine($"--Health: { hero.Health }")
               .AppendLine($"--Armour: { hero.Armour }")
               .AppendLine($"--Weapon: { weaponName }");
            }

           

            return sb.ToString().TrimEnd();
        }

    }
}
