using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private IDictionary<Ticket, Car> parkedCars = new Dictionary<Ticket, Car>();
        private int capacity;

        public ParkingBoy(int capacity = 0)
        {
            this.capacity = capacity;
        }

        public Ticket Park(Car car)
        {
            if (capacity == 0)
            {
                throw new NoPositonException();
            }

            Ticket ticket = new Ticket();
            parkedCars.Add(ticket, car);
            capacity--;
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !parkedCars.ContainsKey(ticket))
            {
                throw new WrongTicketException();
            }

            return parkedCars[ticket];
        }
    }
}
