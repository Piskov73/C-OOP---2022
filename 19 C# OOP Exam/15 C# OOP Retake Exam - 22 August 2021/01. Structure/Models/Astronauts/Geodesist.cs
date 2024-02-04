namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double UnitsOxigen = 50;
        public Geodesist(string name) 
            : base(name, UnitsOxigen)
        {
        }
    }
}
