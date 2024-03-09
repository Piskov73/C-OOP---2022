using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipments;
        public EquipmentRepository()
        {
            this.equipments = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models =>this.equipments.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.equipments.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.equipments.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
           return this.equipments.Remove(model);
        }
    }
}
