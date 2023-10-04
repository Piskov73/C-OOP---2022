namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;
        private FormulaOneCarRepository()
        {
            this.cars= new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.cars.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            this.cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.cars.Find(c=>c.Model==name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.cars.Remove(model);
        }
    }
}
