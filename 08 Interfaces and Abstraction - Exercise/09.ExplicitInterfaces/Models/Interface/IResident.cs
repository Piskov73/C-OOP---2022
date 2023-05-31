namespace ExplicitInterfaces.Models.Interface
{
    public interface IResident : IName

    {
        
        string Country { get; }
        string GetName();
    }
}
