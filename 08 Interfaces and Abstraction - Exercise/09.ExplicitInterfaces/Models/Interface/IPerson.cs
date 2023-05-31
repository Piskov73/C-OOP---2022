namespace ExplicitInterfaces.Models.Interface
{
    public interface IPerson : IName
    {
        int Age { get; }
        string GetName();
    }
}
