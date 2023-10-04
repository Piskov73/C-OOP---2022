namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Contracts;
    using Repositories.Contracts;
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> formulaOneCars;
        public FormulaOneCarRepository()
        {
            this.formulaOneCars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => this.formulaOneCars.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            this.formulaOneCars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return formulaOneCars.FirstOrDefault(x=>x.Model==name);
        }

        public bool Remove(IFormulaOneCar model)
        {
          return formulaOneCars.Remove(model);
        }
    }
}
