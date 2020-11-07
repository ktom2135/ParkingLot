namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_park_a_car()
        {
            // given
            Car car = new Car();
            ParkingBoy parkingBoy = new ParkingBoy();

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
            ParkingBoy parkingBoy = new ParkingBoy();
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
            ParkingBoy parkingBoy = new ParkingBoy();
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
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.Park(car);

            Ticket wrongTicket = new Ticket();

            // when
            // then
            Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));
        }
    }
}
