namespace BirthdayCelebrations.Models.Interface
{
    public interface ICitizen : IName, IIdentifier, IBirthdate
    {
        int Age { get; }
    }
}
