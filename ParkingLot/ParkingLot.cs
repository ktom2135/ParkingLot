using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingLot
    {
        private IDictionary<Ticket, Car> parkedCars = new Dictionary<Ticket, Car>();
        private int capacity;

        public ParkingLot(int capacity = 0)
        {
            this.capacity = capacity;
        }

        public Car Fetch(Ticket ticket)
        {
            ValidateTicket(ticket);

            return FetchCar(ticket);
        }

        public virtual Ticket Park(Car car)
        {
            ValidateCar(car);

            CheckCapacity();

            return ParkCar(car);
        }

        public bool IsFull()
        {
            return capacity - parkedCars.Count() == 0;
        }

        private Car FetchCar(Ticket ticket)
        {
            Car fechedCar = parkedCars[ticket];
            parkedCars.Remove(ticket);
            return fechedCar;
        }

        private void ValidateTicket(Ticket ticket)
        {
            if (!parkedCars.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }

        private Ticket ParkCar(Car car)
        {
            Ticket ticket = new Ticket();
            parkedCars.Add(ticket, car);
            return ticket;
        }

        private void CheckCapacity()
        {
            if (IsFull())
            {
                throw new NoPositonException("Not enough position.");
            }
        }

        private void ValidateCar(Car car)
        {
            if (parkedCars.Values.Contains(car))
            {
                throw new ArgumentException();
            }
        }
    }
}
