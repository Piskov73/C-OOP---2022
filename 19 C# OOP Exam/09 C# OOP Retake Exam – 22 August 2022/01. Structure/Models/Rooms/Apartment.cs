namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int CAPACITY = 6;
        public Apartment( )
            : base(CAPACITY)
        {
        }
    }
}
