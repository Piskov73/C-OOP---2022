namespace MilitaryElite.Models.Interfaces
{
    using Enums;

    public interface IMissions
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
