using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            string result = string.Empty;

            List<IHero> knights=players.Where(x=>x.GetType().Name==nameof(Knight)).ToList();
            List<IHero> barbarians=players.Where(x=>x.GetType().Name==nameof (Barbarian)).ToList();
            int countKkights=knights.Count;
            int countBarbarians=barbarians.Count;
            int deadKnights = 0;
            int deadBarbarians = 0;
            bool end=false;
            while (true)
            {
                foreach (var k in knights)
                {
                    if(k.IsAlive==false)
                    {
                        continue;
                    }

                    foreach (var bar in barbarians)
                    {
                        if (bar.IsAlive==false)
                        {
                            continue;
                        }
                        bar.TakeDamage(k.Weapon.DoDamage());
                        if (bar.IsAlive == false)
                        {
                            countBarbarians--;
                            deadBarbarians++;
                            if (countBarbarians == 0)
                            {
                                end = true;
                                break;
                            }
                        }
                    }
                    if (end)
                    {
                        break;
                    }
                }
                if (end) break;

                foreach(var bar in barbarians)
                {
                    if (!bar.IsAlive)
                    {
                        continue;
                    }

                    foreach (var k in knights)
                    {
                        if (!k.IsAlive)
                        {
                            continue;
                        }

                        k.TakeDamage(bar.Weapon.DoDamage());
                        if (!k.IsAlive)
                        {
                            countKkights--;
                            deadKnights++;
                            if(countKkights == 0)
                            {
                                end = true;
                                break;
                            }
                        }
                    }
                    if(end) break;

                }
                if (end) break;


            }
            if(countBarbarians==0)
            {
                result = string.Format(OutputMessages.MapFightKnightsWin,deadKnights);
            }
            else
            {
                result = string.Format(OutputMessages.MapFigthBarbariansWin, deadBarbarians);
            }

            return result;
        }
    }
}
