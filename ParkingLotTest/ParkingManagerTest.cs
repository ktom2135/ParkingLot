namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using ParkingLot;
    using Xunit;

    public class ParkingManagerTest
    {
        private ParkingManager defaultParkingManager;

        public ParkingManagerTest()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(10) };
            defaultParkingManager = new ParkingManager(parkingLots);
        }

        [Fact]
        public void Should_return_ticket_when_park_a_car()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;

            // when
            Ticket ticket = parkingManager.Park(car);

            // then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_car_when_fetch_given_ticket()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            Ticket ticket = parkingManager.Park(car);

            // when
            Car fetchedCar = parkingManager.Fetch(ticket);

            // then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Should_return_right_car_when_fetch_given_correspond_ticket()
        {
            // given
            Car carA = new Car();
            Car carB = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            Ticket ticketA = parkingManager.Park(carA);
            Ticket ticketB = parkingManager.Park(carB);

            // when
            Car fetchedCarA = parkingManager.Fetch(ticketA);
            Car fetchedCarB = parkingManager.Fetch(ticketB);

            // then
            Assert.Equal(carA, fetchedCarA);
            Assert.Equal(carB, fetchedCarB);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_wrong_ticket()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            parkingManager.Park(car);

            Ticket wrongTicket = new Ticket();

            // when
            // then
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingManager.Fetch(wrongTicket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_no_ticket()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            parkingManager.Park(car);

            // when
            // then
            NoTicketProvidedException exception = Assert.Throws<NoTicketProvidedException>(() => parkingManager.Fetch(null));
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            Ticket ticket = parkingManager.Park(car);
            parkingManager.Fetch(ticket);

            // when
            // then
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingManager.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_has_no_position()
        {
            // given
            Car carA = new Car();
            Car carB = new Car();
            ParkingManager parkingManager = new ParkingManager(new List<ParkingLot> { new ParkingLot(1) });
            Ticket ticket = parkingManager.Park(carA);

            // when
            // then
            NoPositonException exception = Assert.Throws<NoPositonException>(() => parkingManager.Park(carB));
            Assert.Equal("Not enough position.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_parked_car()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            parkingManager.Park(car);

            // when
            // then
            Assert.Throws<ArgumentException>(() => parkingManager.Park(car));
        }

        [Fact]
        public void Should_throw_exception_when_park_given_null_car()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;

            // when
            // then
            Assert.Throws<ArgumentNullException>(() => parkingManager.Park(null));
        }

        [Fact]
        public void Should_park_to_second_parking_lot_when_park_given_first_parking_lot_is_full()
        {
            // given
            Car car = new Car();
            ParkingLot firstParkingLot = CreateFullParkingLot();
            Mock<ParkingLot> secondParkingLot = new Mock<ParkingLot>(1);
            secondParkingLot.Setup(mock => mock.Park(It.IsAny<Car>())).Returns(new Ticket());
            ParkingManager parkingManager = new ParkingManager(new List<ParkingLot> { firstParkingLot, secondParkingLot.Object });

            // when
            Ticket ticket = parkingManager.Park(car);

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
            ParkingManager parkingManager = new ParkingManager(new List<ParkingLot> { firstParkingLot, secondParkingLot });
            Ticket ticket = parkingManager.Park(car);

            // when
            Car fetchedCar = parkingManager.Fetch(ticket);

            // then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Should_contain_specify_parking_body_when_get_management_list_given_already_added()
        {
            // given
            ParkingManager parkingManager = defaultParkingManager;
            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot>());
            parkingManager.AddParkingBoy(parkingBoy);

            // when
            List<ParkingBoy> managedParkingBoys = parkingManager.GetManagedParkingBoys();

            // then
            Assert.Contains(parkingBoy, managedParkingBoys);
        }

        [Fact]
        public void Should_park_to_parking_lot_managed_by_parking_boy_when_specify_boy()
        {
            // given
            Car car = new Car();
            Ticket ticket = new Ticket();
            ParkingManager parkingManager = defaultParkingManager;
            Mock<ParkingLot> boyManagedParkingLot = new Mock<ParkingLot>(1);
            boyManagedParkingLot.Setup(mock => mock.Park(car)).Returns(ticket);

            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot>() { boyManagedParkingLot.Object });
            parkingManager.AddParkingBoy(parkingBoy);

            // when
            Ticket ticketFromBoy = parkingManager.ParkByBoy(parkingBoy, car);

            // then
            boyManagedParkingLot.Verify(parkingLot => parkingLot.Park(car));
        }

        [Fact]
        public void Should_fetch_from_parking_lot_managed_by_parking_boy_when_specify_boy()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            Mock<ParkingLot> boyManagedParkingLot = new Mock<ParkingLot>(1);
            boyManagedParkingLot.Setup(mock => mock.Park(It.IsAny<Car>())).CallBase();
            boyManagedParkingLot.Setup(mock => mock.Fetch(It.IsAny<Ticket>())).CallBase();

            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot>() { boyManagedParkingLot.Object });
            parkingManager.AddParkingBoy(parkingBoy);

            // when
            Ticket ticket = parkingManager.ParkByBoy(parkingBoy, car);
            Car fetchedCar = parkingManager.FetchByBoy(parkingBoy, ticket);

            // then
            boyManagedParkingLot.Verify(parkingLot => parkingLot.Fetch(ticket));
            Assert.Equal(fetchedCar, car);
        }

        [Fact]
        public void Should_display_error_message_to_customer_when_park_failed_by_specify_boy()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            ParkingLot boyManagedParkingLot = CreateFullParkingLot();

            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot>() { boyManagedParkingLot });
            parkingManager.AddParkingBoy(parkingBoy);

            // when
            // then
            NoPositonException exception = Assert.Throws<NoPositonException>(() => parkingManager.ParkByBoy(parkingBoy, car));
            Assert.Equal("Not enough position.", exception.Message);
        }

        [Fact]
        public void Should_display_error_message_to_customer_when_fetch_failed_by_specify_boy()
        {
            // given
            Car car = new Car();
            ParkingManager parkingManager = defaultParkingManager;
            ParkingLot boyManagedParkingLot = new ParkingLot(1);

            ParkingBoy parkingBoy = new ParkingBoy(new List<ParkingLot>() { boyManagedParkingLot });
            parkingManager.AddParkingBoy(parkingBoy);

            Ticket wrongTicket = new Ticket();

            // when
            // then
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingManager.FetchByBoy(parkingBoy, wrongTicket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        private static ParkingLot CreateFullParkingLot()
        {
            ParkingLot parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());
            return parkingLot;
        }
    }
}
