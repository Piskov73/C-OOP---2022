namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int CAPACITY = 2;
        public DoubleBed()
            : base(CAPACITY)
        {
        }
    }
}
