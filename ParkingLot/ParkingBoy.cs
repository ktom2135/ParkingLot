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
            this.ParkingLots = parkingLots;
        }

        protected List<ParkingLot> ParkingLots { get; }

        public Car Fetch(Ticket ticket)
        {
            ValidateTicket(ticket);

            ParkingLot parkingLot = ParkingLots.FirstOrDefault(parkingLot => parkingLot.HasVehicle(ticket));

            if (parkingLot == null)
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            return parkingLot.Fetch(ticket);
        }

        public virtual Ticket Park(Car car)
        {
            ValidateCar(car);

            ParkingLot availableParkingLot = ParkingLots.FirstOrDefault(parkingLot => !parkingLot.IsFull());

            if (availableParkingLot == null)
            {
                throw new NoPositonException("Not enough position.");
            }

            return availableParkingLot.Park(car);
        }

        protected void ValidateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void ValidateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new NoTicketProvidedException("Please provide your parking ticket.");
            }
        }
    }
}
