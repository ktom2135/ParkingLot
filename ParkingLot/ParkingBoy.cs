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

        public Car Fetch(Ticket ticket)
        {
            ValidateTicket(ticket);

            return FetchCar(ticket);
        }

        public Ticket Park(Car car)
        {
            ValidateCar(car);

            CheckCapacity();

            return ParkCar(car);
        }

        private Car FetchCar(Ticket ticket)
        {
            Car fechedCar = parkedCars[ticket];
            parkedCars.Remove(ticket);
            return fechedCar;
        }

        private void ValidateTicket(Ticket ticket)
        {
            if (ticket == null || !parkedCars.ContainsKey(ticket))
            {
                throw new WrongTicketException();
            }
        }

        private Ticket ParkCar(Car car)
        {
            Ticket ticket = new Ticket();
            parkedCars.Add(ticket, car);
            capacity--;
            return ticket;
        }

        private void CheckCapacity()
        {
            if (capacity == 0)
            {
                throw new NoPositonException();
            }
        }

        private void ValidateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException();
            }

            if (parkedCars.Values.Contains(car))
            {
                throw new ArgumentException();
            }
        }
    }
}
