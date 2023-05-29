namespace MilitaryElite.Models.Interface
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
