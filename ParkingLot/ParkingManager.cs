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
    }
}
