using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private IDictionary<Ticket, Car> parkedCars = new Dictionary<Ticket, Car>();

        public ParkingBoy()
        {
        }

        public Ticket Park(Car car)
        {
            Ticket ticket = new Ticket();
            parkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (!parkedCars.ContainsKey(ticket))
            {
                throw new WrongTicketException();
            }

            return parkedCars[ticket];
        }
    }
}
