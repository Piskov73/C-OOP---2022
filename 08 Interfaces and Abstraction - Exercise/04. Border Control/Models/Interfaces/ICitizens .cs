namespace BorderControl.Models.Interfaces
{
    public interface ICitizens : IPopulation
    {
        string Name { get; }
        int Age { get; }
       
    }
}
