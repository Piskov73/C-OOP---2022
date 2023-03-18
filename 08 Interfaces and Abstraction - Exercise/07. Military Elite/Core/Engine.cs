namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using IO.Interfaces;
    using MilitaryElite.Models.Enums;
    using Models;
    using Models.Interfaces;


    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;
        private readonly ICollection<ISoldier> allSoldier;
       
        public Engine(IRead read, IWrite write)
        {
            this.read = read;
            this.write = write;
            this.allSoldier = new HashSet<ISoldier>();
        }
        public void Run()
        {
            string comand;
            while ((comand = this.read.ReadLine()) != "End")
            {
                string[] comArg = comand.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                string soldierType = comArg[0];
                int id = int.Parse(comArg[1]);
                string firstName = comArg[2];
                string lastName = comArg[3];
                decimal salary;
                ISoldier soldier=null;
                switch (soldierType)
                {
                    case "Private":
                        salary = decimal.Parse(comArg[4]);
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(comArg[4]);
                        ICollection<IPrivate> privates = FindPrivate(comArg);
                        soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(comArg[4]);
                        string corpsText = comArg[5];
                        bool corpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                        if (!corpsValid)
                        {
                            continue;
                        }
                        ICollection<IRepair> repairs = CreateRepair(comArg);
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        break;
                    case "Commando":
                        salary = decimal.Parse(comArg[4]);
                        string corpsTex = comArg[5];
                        bool corpsValidComando = Enum.TryParse<Corps>(corpsTex, false, out Corps corp);
                        if (!corpsValidComando)
                        {
                            continue;
                        }
                        ICollection<IMissions> missions= CreateMissions(comArg);
                        soldier=new Commando(id,firstName, lastName, salary,corp, missions);

                        break;
                    case "Spy":
                        int codeNumber = int.Parse(comArg[4]);
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                }
                this.allSoldier.Add(soldier);
            }
            foreach (var soldier in this.allSoldier)
            {
                write.WriteLine(soldier.ToString());
            }
        }
        private ICollection<IPrivate> FindPrivate(string[] cmdArg)
        {
            int[] privatesIds = cmdArg.Skip(5).Select(int.Parse).ToArray();
            ICollection<IPrivate> privates = new HashSet<IPrivate>();
            foreach (var item in privatesIds)
            {
                IPrivate filterSolder = (IPrivate)this.allSoldier.FirstOrDefault(x => x.Id == item);
                if (filterSolder != null)
                {
                    privates.Add(filterSolder);
                }
            }
            return privates;

        }
        private ICollection<IRepair> CreateRepair(string[] cmdArg)
        {
            string[] repairsInfo = cmdArg.Skip(6).ToArray();
            ICollection<IRepair> repairs = new HashSet<IRepair>();
            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);
                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);

            }
            return repairs;


        }
        private ICollection<IMissions> CreateMissions(string[] cmdArg)
        {
            string[] missionsInfo = cmdArg.Skip(6).ToArray();
            ICollection<IMissions> missions = new HashSet<IMissions>();
            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];
                string stateT = missionsInfo[i + 1];
                bool stateValid=Enum.TryParse<State>(stateT,false, out State state);
                if (!stateValid)
                {
                    continue;
                }
                IMissions mission = new Mission(codeName, state);
                missions.Add(mission);

            }
            return missions;
        }
    }
}
