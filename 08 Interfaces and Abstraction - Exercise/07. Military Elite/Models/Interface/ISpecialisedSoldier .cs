namespace MilitaryElite.Models.Interface
{
    using Enum;
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
