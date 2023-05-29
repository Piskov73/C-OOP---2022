namespace MilitaryElite.Core
{
    using Interface;
    using MilitaryElite.IO.Interface;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Enum;
    using MilitaryElite.Models.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;
        private readonly ICollection<ISoldier> soldiers;
        private Engine()
        {
            this.soldiers = new HashSet<ISoldier>();
        }
        public Engine(IRead read, IWrite write) : this()
        {
            this.read = read;
            this.write = write;
        }
        public void Run()
        {
            ISoldier soldier = null;
            string comand = string.Empty;
            while ((comand = read.ReadLine()) != "End")
            {
                string[] infoSoldier = comand.Split(' ');
                string typrSoldier = infoSoldier[0];
                int id = int.Parse(infoSoldier[1]);
                string firstName = infoSoldier[2];
                string lastName = infoSoldier[3];
                decimal salary;

                if (typrSoldier == "Private")
                {
                    salary = decimal.Parse(infoSoldier[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(soldier);
                }
                else if (typrSoldier == "LieutenantGeneral")
                {
                    salary = decimal.Parse(infoSoldier[4]);
                    ICollection<IPrivate> privates = CollectionPrivate(infoSoldier);
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    soldiers.Add(soldier);
                }
                else if (typrSoldier == "Engineer")
                {
                    salary = decimal.Parse(infoSoldier[4]);

                    string corpsEngineer = infoSoldier[5];

                    bool chekCorps = Enum.TryParse<Corps>(corpsEngineer, false, out Corps corps);

                    if (!chekCorps)
                        continue;

                    ICollection<IRepair> repairs = CollectionRipairs(infoSoldier);

                    soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);

                    soldiers.Add(soldier);
                }
                else if (typrSoldier == "Commando")
                {
                    salary = decimal.Parse(infoSoldier[4]);

                    string commandoCorps = infoSoldier[5];

                    bool validCorps = Enum.TryParse<Corps>(commandoCorps, false, out Corps corps);

                    if (!validCorps)
                        continue;

                    ICollection<IMission> missions = CollectionMissions(infoSoldier);

                    soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                    soldiers.Add(soldier);
                }
                else if (typrSoldier == "Spy")
                {
                    int codeNumber = int.Parse(infoSoldier[4]);
                    soldier = new Spy(id,firstName,lastName,codeNumber);
                    soldiers.Add(soldier);
                }

            }

            foreach (var item in soldiers)
            {
                write.WriteLine(item.ToString());
            }
        }
        private ICollection<IPrivate> CollectionPrivate(string[] infoSoldier)
        {
            ICollection<IPrivate> privates = new HashSet<IPrivate>();
            string[] idPrivates = infoSoldier.Skip(5).ToArray();
            foreach (var item in idPrivates)
            {
                int id = int.Parse(item);
                var pr = soldiers.FirstOrDefault(s => s.ID == id);

                if (pr != null)
                    privates.Add((IPrivate)pr);

            }
            return privates;
        }
        private ICollection<IRepair> CollectionRipairs(string[] infoSoldier)
        {
            ICollection<IRepair> ripairs = new HashSet<IRepair>();
            string[] ripairInfo = infoSoldier.Skip(6).ToArray();
            for (int i = 0; i < ripairInfo.Length; i += 2)
            {
                string partName = ripairInfo[i];
                int hoursWorked = int.Parse(ripairInfo[i + 1]);
                IRepair ripair = new Repair(partName, hoursWorked);
                ripairs.Add(ripair);
            }

            return ripairs;
        }
        private ICollection<IMission> CollectionMissions(string[] infoSoldier)
        {
            ICollection<IMission> missions = new HashSet<IMission>();
            string[] infoMission=infoSoldier.Skip(6).ToArray();
            for (int i = 0;i < infoMission.Length;i+= 2)
            {
                string codeName = infoMission[i];

                string stateMission = infoMission[i + 1];

                bool validMission = Enum.TryParse<State>(stateMission, false, out State state);

                if (!validMission)
                    continue;

                IMission mission = new Mission(codeName,state);
                missions.Add(mission);
            }
            return missions;
        }
    }
}
