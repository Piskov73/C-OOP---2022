namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int CAPACITY = 4;
        public Studio() 
            : base(CAPACITY)
        {
        }
    }
}
