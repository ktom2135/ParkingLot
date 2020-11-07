namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        private ParkingBoy defaultParkingBoy;

        public ParkingBoyTest()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(10) };
            defaultParkingBoy = new ParkingBoy(parkingLots);
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
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
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
            NoTicketProvidedException exception = Assert.Throws<NoTicketProvidedException>(() => parkingBoy.Fetch(null));
            Assert.Equal("Please provide your parking ticket.", exception.Message);
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
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_has_no_position()
        {
            // given
            Car carA = new Car();
            Car carB = new Car();
            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(1) });
            Ticket ticket = parkingBoy.Park(carA);

            // when
            // then
            NoPositonException exception = Assert.Throws<NoPositonException>(() => parkingBoy.Park(carB));
            Assert.Equal("Not enough position.", exception.Message);
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

        [Fact]
        public void Should_park_to_second_parking_lot_when_park_given_first_parking_lot_is_full()
        {
            // given
            Car car = new Car();
            ParkingLot firstParkingLot = CreateFullParkingLot();
            Mock<ParkingLot> secondParkingLot = new Mock<ParkingLot>(1);
            secondParkingLot.Setup(mock => mock.Park(It.IsAny<Car>())).Returns(new Ticket());
            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot> { firstParkingLot, secondParkingLot.Object });

            // when
            Ticket ticket = parkingBoy.Park(car);

            // then
            secondParkingLot.Verify(parkingLot => parkingLot.Park(car));
        }

        [Fact]
        public void Should_return_car_when_fetch_given_multi_parking_lots()
        {
            // given
            Car car = new Car();
            ParkingLot firstParkingLot = CreateFullParkingLot();
            ParkingLot secondParkingLot = new ParkingLot(1);
            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot> { firstParkingLot, secondParkingLot });
            Ticket ticket = parkingBoy.Park(car);

            // when
            Car fetchedCar = parkingBoy.Fetch(ticket);

            // then
            Assert.Equal(car, fetchedCar);
        }

        private static ParkingLot CreateFullParkingLot()
        {
            ParkingLot parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());
            return parkingLot;
        }
    }
}
