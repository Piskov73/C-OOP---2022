namespace MilitaryElite.Models.Interface
{
    using Enum;
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();

    }
}
