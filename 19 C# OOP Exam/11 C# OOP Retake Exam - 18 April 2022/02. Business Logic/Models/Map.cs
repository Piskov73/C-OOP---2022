using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            string output = string.Empty;

            List<IHero> knights=players.Where(x=>x.GetType().Name == nameof(Knight)).ToList();
            List<IHero> barbarians=players.Where(x=>x.GetType().Name == nameof(Barbarian)).ToList();
            int countDeadKnidhts = 0;
            int countDeadBarbarians = 0;
            bool endBattle=false;
            while (true)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive == false) continue;
                    foreach (var barbaian in barbarians)
                    {
                        if (barbaian.IsAlive == false) continue;

                        barbaian.TakeDamage(knight.Weapon.DoDamage());

                        if(barbaian.IsAlive == false) countDeadBarbarians++;

                        if(countDeadBarbarians == barbarians.Count)
                        {
                            output = string.Format(OutputMessages.MapFightKnightsWin,countDeadKnidhts);
                            endBattle = true; break;
                        }
                    }
                    if (endBattle) break;
                }
                if (endBattle) break;
                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive == false) continue;

                    foreach (var knight in knights)
                    {
                        if (knight.IsAlive == false) continue;

                        knight.TakeDamage(barbarian.Weapon.DoDamage());

                        if(knight.IsAlive==false) countDeadKnidhts++;

                        if(countDeadKnidhts==knights.Count)
                        {
                            output = string.Format(OutputMessages.MapFigthBarbariansWin, countDeadBarbarians);
                            endBattle = true; break;
                        }
                    }
                    if (endBattle) break;
                }
                if (endBattle) break;
            }

            return output;
        }
    }
}
