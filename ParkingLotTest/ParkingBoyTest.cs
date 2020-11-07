namespace ParkingLotTest
{
    using System;
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        private ParkingBoy defaultParkingBoy;

        public ParkingBoyTest()
        {
            defaultParkingBoy = new ParkingBoy(10);
        }

        [Fact]
        public void Should_return_ticket_when_park_a_car()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;

            // when
            Ticket ticket = parkingBoy.Park(car);

            // then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_car_when_fetch_given_ticket()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;
            Ticket ticket = parkingBoy.Park(car);

            // when
            Car fetchedCar = parkingBoy.Fetch(ticket);

            // then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Should_return_right_car_when_fetch_given_correspond_ticket()
        {
            // given
            Car carA = new Car();
            Car carB = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;
            Ticket ticketA = parkingBoy.Park(carA);
            Ticket ticketB = parkingBoy.Park(carB);

            // when
            Car fetchedCarA = parkingBoy.Fetch(ticketA);
            Car fetchedCarB = parkingBoy.Fetch(ticketB);

            // then
            Assert.Equal(carA, fetchedCarA);
            Assert.Equal(carB, fetchedCarB);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_wrong_ticket()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;
            parkingBoy.Park(car);

            Ticket wrongTicket = new Ticket();

            // when
            // then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_no_ticket()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;
            parkingBoy.Park(car);

            // when
            // then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(null));
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;
            Ticket ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            // when
            // then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_throw_exception_when_park_given_has_no_position()
        {
            // given
            Car carA = new Car();
            Car carB = new Car();
            ParkingBoy parkingBoy = new ParkingBoy(1);
            Ticket ticket = parkingBoy.Park(carA);

            // when
            // then
            Assert.Throws<NoPositonException>(() => parkingBoy.Park(carB));
        }

        [Fact]
        public void Should_throw_exception_when_park_given_parked_car()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;
            parkingBoy.Park(car);

            // when
            // then
            Assert.Throws<ArgumentException>(() => parkingBoy.Park(car));
        }

        [Fact]
        public void Should_throw_exception_when_park_given_null_car()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = defaultParkingBoy;

            // when
            // then
            Assert.Throws<ArgumentNullException>(() => parkingBoy.Park(null));
        }
    }
}
