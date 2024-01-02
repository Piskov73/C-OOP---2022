using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;
        public RobotRepository() 
        { 
            this.robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
         this.robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return this.robots.FirstOrDefault(x=>x.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()=>this.robots.AsReadOnly();
       

        public bool RemoveByName(string typeName)
        {
            return this.robots.Remove(this.robots.FirstOrDefault(x => x.Model == typeName));
        }
    }
}
