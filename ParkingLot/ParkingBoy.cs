using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(int capacity = 0)
        {
            parkingLot = new ParkingLot(capacity);
        }

        public Car Fetch(Ticket ticket)
        {
            return parkingLot.Fetch(ticket);
        }

        public Ticket Park(Car car)
        {
            return parkingLot.Park(car);
        }
    }
}
