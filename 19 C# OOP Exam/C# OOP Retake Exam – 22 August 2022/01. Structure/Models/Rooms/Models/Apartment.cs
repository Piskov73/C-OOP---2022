using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms.Models
{
    public class Apartment : Room
    {
        private const int bedCapacity = 6;

        public Apartment()
            : base(bedCapacity)
        {
        }
    }
}
