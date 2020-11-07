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
    }
}
