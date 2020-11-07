using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Car Fetch(Ticket ticket)
        {
            return parkingLots[0].Fetch(ticket);
        }

        public Ticket Park(Car car)
        {
            ParkingLot availableParkingLot = parkingLots.FirstOrDefault(parkingLot => !parkingLot.IsFull());

            if (availableParkingLot == null)
            {
                throw new NoPositonException("Not enough position.");
            }

            return availableParkingLot.Park(car);
        }
    }
}
