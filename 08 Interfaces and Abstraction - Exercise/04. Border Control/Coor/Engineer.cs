namespace BorderControl.Coor
{
    using System;
    using System.Collections.Generic;
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    using Interfaces;
    using IO.Interfaces;

    public class Engineer : IEngineer
    {
        private readonly IReader reader;
        private readonly IWrite write;
        private List<IPopulation> population;
        
        public Engineer(IReader reader,IWrite write)
        {
            this.reader = reader;
            this.write = write;
            population = new List<IPopulation>();
        }
        public void Run()
        {
            
            string input = reader.ReadLine();
            while (input != "End")
            {
                string[] token = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
               
                    if (token.Length == 2)
                    {
                        string model = token[0];
                        string irRobot= token[1];
                        IPopulation robot=new Robots(model,irRobot);
                        population.Add(robot);
                    }
                    else if(token.Length==3)
                    {
                        string name= token[0];
                        int age = int.Parse(token[1]);
                        string idCiti = token[2];
                        IPopulation citisen=new Citizens(name,age,idCiti);
                        population.Add(citisen);
                    }
                    input = reader.ReadLine();
                
            
               
            }
            string digitsOfFakeIds = reader.ReadLine();
            foreach (var item in population)
            {
                if (item.Id.EndsWith(digitsOfFakeIds))
                {
                    write.WriteLine(item.Id);
                }
                //if (ChekFakeIds(item.Id,digitsOfFakeIds))
                //{
                //    write.WriteLine(item.Id);
                //}
            }
           
            
        }

        private bool ChekFakeIds(string id, string digitsOfFakeIds)
        {
            int count= 0;
            for (int i = id.Length-digitsOfFakeIds.Length; i < id.Length; i++)
            {
                if (id[i] != digitsOfFakeIds[count] )
                {
                    return false;
                }
                count++;
            }
            return true;
        }
    }
}
