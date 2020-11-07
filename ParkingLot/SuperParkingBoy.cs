using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SuperParkingBoy : ParkingBoy
    {
        public SuperParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Park(Car car)
        {
            ValidateCar(car);

            ParkingLot availableParkingLot = this.ParkingLots.Where(parkingLot => !parkingLot.IsFull()).OrderByDescending(order => order.AvailablePositionRate()).FirstOrDefault();

            if (availableParkingLot == null)
            {
                throw new NoPositonException("Not enough position.");
            }

            return availableParkingLot.Park(car);
        }
    }
}
