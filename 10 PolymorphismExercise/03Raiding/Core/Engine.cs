namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;
    using Raiding.Factory.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICreateHeroFactory factory;
        private readonly ICollection<IBaseHero> raidGroup;
        private Engine()
        {
            this.raidGroup = new HashSet<IBaseHero>();
        }
        public Engine(IReader reader, IWriter writer, ICreateHeroFactory factory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;
        }
        public void Run()
        {
            CreateRaidGroup();

            int sumPowers = 0;
            if (raidGroup.Count > 0)
                sumPowers = raidGroup.Sum(p => p.Power);

            int powerBoss = int.Parse(reader.ReadLine());

            Print();

            writer.WriteLine(BattleResult(sumPowers, powerBoss));

        }
        private void CreateRaidGroup()
        {
            int n = int.Parse(reader.ReadLine());
            while (true)
            {
                try
                {
                    string name = reader.ReadLine();
                    string typeHero = reader.ReadLine();
                    IBaseHero hero = factory.CreateHeroFactory(name, typeHero);
                    raidGroup.Add(hero);
                    if (raidGroup.Count == n) break;

                }
                catch (ArgumentException arge)
                {

                    writer.WriteLine(arge.Message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
          

        }
        private string BattleResult(int sumPowers, int powerBoss)
        {
            string output = "";
            if (sumPowers >= powerBoss)
            {
                output = "Victory!";
            }
            else
            {
                output = "Defeat...";
            }
            return output;
        }
        private void Print()
        {
            foreach (var hero in raidGroup)
            {
                writer.WriteLine(hero.CastAbility());
            }
        }
    }
}
