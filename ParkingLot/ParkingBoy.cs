using System;
namespace ParkingLot
{
    public class ParkingBoy
    {
        private Car parkedCar;

        public ParkingBoy()
        {
        }

        public Ticket Park(Car car)
        {
            parkedCar = car;
            return new Ticket();
        }

        public Car Fetch(Ticket ticket)
        {
            return parkedCar;
        }
    }
}
