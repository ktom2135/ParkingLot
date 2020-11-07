using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingManager : ParkingBoy
    {
        private List<ParkingBoy> managedParkingBoys = new List<ParkingBoy>();

        public ParkingManager(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            managedParkingBoys.Add(parkingBoy);
        }

        public List<ParkingBoy> GetManagedParkingBoys()
        {
            return managedParkingBoys;
        }

        public Ticket ParkByBoy(ParkingBoy parkingBoy, Car car)
        {
            return parkingBoy.Park(car);
        }

        public Car FetchByBoy(ParkingBoy parkingBoy, Ticket ticket)
        {
            return parkingBoy.Fetch(ticket);
        }
    }
}
