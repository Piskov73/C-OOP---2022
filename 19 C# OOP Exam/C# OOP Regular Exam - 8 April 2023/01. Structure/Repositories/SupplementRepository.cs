using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;

        public SupplementRepository() 
        {
            this.supplements = new List<ISupplement>();
        }
        public IReadOnlyCollection<ISupplement> Models()=>this.supplements.AsReadOnly();
       

        public void AddNew(ISupplement model)
        {
            this.supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return this.supplements.FirstOrDefault(x=>x.InterfaceStandard==interfaceStandard);
        }

     

        public bool RemoveByName(string typeName)
        {
            return this.supplements.Remove(Models().FirstOrDefault(x=>x.GetType().Name == typeName));
        }
    }
}
